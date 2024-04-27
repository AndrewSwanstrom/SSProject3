using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    static bool fireWin;
    public static bool iceWin;
    static bool electricWin;
    public static bool firstTimeIce = false;
    public static bool firstTimeElectric = false;
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float rotationSpeed = 600f;
    public float jumpForce = 8f;
    public float gravityScale = 2f;
    public float maxStamina = 100f;
    public float sprintDepletionRate = 20f;
    public float sprintRechargeRate = 10f;
    public float rotationCameraSpeed = 50f;
    public float rotationLagSpeed = 5f;
    public bool icePuzzle = false;

    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip fireStart;
    public AudioClip fireEnd;

    public GameObject electricHolder;
    public GameObject iceHolder;
    public GameObject fireHolder;

    [SerializeField] private float electricPowerCurrent;
    [SerializeField] private float electricPowerMax;
    [SerializeField] private float icePowerCurrent;
    [SerializeField] private float icePowerMax;
    [SerializeField] private float firePowerCurrent;
    [SerializeField] private float firePowerMax;
    [SerializeField] private Image electricPowerBar;
    [SerializeField] private Image icePowerBar;
    [SerializeField] private Image firePowerBar;

    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;

    Animator animator;

    Vector2 lookDirection = new Vector2(1,0);

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool theTrueisGrounded;
    private bool isSprinting;
    public float currentStamina;
    public bool electricPower;
    public bool icePower;
    public bool firePower;

    public Transform cameraTransform;
    bool isElectric;
    public GameObject electricOrb;
    private float amount = 5f;

    bool fireAbility;

    string[] abilities;
    int rotationNum;

    void Start()
    {
        icePuzzle = false;
        characterController = GetComponent<CharacterController>();
        currentStamina = maxStamina;
        animator = GetComponent<Animator>();
        isElectric = false;
        electricPower = false;
        Time.timeScale = 1f;
        rotationNum = 0;
        fireAbility = false;
        electricHolder.SetActive(false);
        iceHolder.SetActive(false);
        fireHolder.SetActive(false);
        electricPowerMax = 5;
        electricPowerCurrent = electricPowerMax;
        icePowerMax = 2;
        icePowerCurrent = icePowerMax;
        firePowerMax = 5;
        firePowerCurrent = firePowerMax;
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
        Jump();
        Sprint();
        RotateCamera();
        UpdateIcePower();
        UpdateFirePower();
        UpdateElectricPower();
        if(!GroundCheck())
        {
            animator.SetBool("isJumpBase",true);
        }
        else
        {
            animator.SetBool("isJumpBase",false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance,boxSize);
    }

    bool GroundCheck()
    {
        if(Physics.BoxCast(transform.position, boxSize, -transform.up, transform.rotation, maxDistance, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //player movement
    void MovePlayer()
    {
        Vector3 cameraEulerAngles = cameraTransform.eulerAngles;
        cameraEulerAngles.x = 0f;
        cameraEulerAngles.z = 0f;

        Quaternion targetRotation = Quaternion.Euler(cameraEulerAngles);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontalInput, verticalInput);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector3 control = new Vector3 (1,0,1);
        Vector3 camForward = cameraTransform.forward.normalized;
        camForward.y = 0;
        Vector3 camRight = cameraTransform.right.normalized;

        Vector3 forwardRelative = verticalInput * camForward;
        Vector3 rightRelative = horizontalInput * camRight;

        Vector3 moveDirection = (forwardRelative + rightRelative).normalized;

        float speed = isSprinting ? sprintSpeed : moveSpeed;

        characterController.Move(moveDirection * speed * Time.deltaTime);

        if (!isGrounded)
        {
            playerVelocity.y += Physics.gravity.y * gravityScale * Time.deltaTime;
        }
        if(rotationNum == 1)
        {
            animator.SetBool("Electric", true);
            electricHolder.SetActive(true);
            iceHolder.SetActive(false);
            fireHolder.SetActive(false);
            if(!electricPower)
            {
                if(electricPowerCurrent<electricPowerMax)
                {
                    electricPowerCurrent += Time.deltaTime;
                }
            }
            else if(electricPower)
            {
                if(electricPowerCurrent>0)
                {
                    electricPowerCurrent -= Time.deltaTime;
                }
            }
            if(Input.GetKeyDown(KeyCode.Z)&&!electricPower&&electricPowerCurrent>0)
            {
                animator.SetBool("ElectricPower", true);
                electricPower = true;
                moveSpeed = 0;
                sprintSpeed = 0;
            }
            else if(electricPower&& Input.GetKeyDown(KeyCode.Z) || electricPowerCurrent<=0)
            {
                animator.SetBool("ElectricPower",false);
                electricPower = false;
                moveSpeed = 5f;
                sprintSpeed = 8f;
            }
        }
        else if(rotationNum == 2)
        {
            Scene scene = SceneManager.GetActiveScene();
            iceHolder.SetActive(true);
            fireHolder.SetActive(false);
            electricHolder.SetActive(false);
            animator.SetBool("Ice",true);
            animator.SetBool("Electric", false);
            animator.SetBool("Fire",false);
            if(icePowerCurrent<icePowerMax)
            {
                icePowerCurrent += Time.deltaTime;
            }
            if(!GroundCheck() && Input.GetKeyDown(KeyCode.Z) && icePowerCurrent >= 2)
            {
                animator.SetBool("Ice Ability",true);
                characterController.Move(Vector3.down * moveSpeed * Time.deltaTime);
                icePowerCurrent -= 2;
                if(scene.name == "IceLevel")
                {
                    icePuzzle = true;
                }
            }
        }
        else if(rotationNum == 3)
        {
            fireHolder.SetActive(true);
            iceHolder.SetActive(false);
            electricHolder.SetActive(false);
            animator.SetBool("Fire",true);
            animator.SetBool("Ice",false);
            animator.SetBool("Electric", false);
            animator.SetBool("IceAbility",false);
            if(!fireAbility)
            {
                if(firePowerCurrent<firePowerMax)
                {
                    firePowerCurrent += Time.deltaTime;
                }
            }
            else if(fireAbility)
            {
                if(firePowerCurrent>0)
                {
                    firePowerCurrent -= Time.deltaTime;
                }
            }
            if(Input.GetKeyDown(KeyCode.Z) && !fireAbility && firePowerCurrent>0)
            {
                animator.SetBool("StartRun",true);
                animator.SetBool("FireTrigger",false);
                audioSource.PlayOneShot(fireStart);
                moveSpeed = 8f;
                fireAbility = true;
            }
            else if(Input.GetKeyDown(KeyCode.Z) && fireAbility || firePowerCurrent<=0)
            {
                fireAbility = false;
                animator.SetBool("StopRun", true);
                audioSource.PlayOneShot(fireEnd);
                moveSpeed = 5f;
            }
        }
        else
        {
            animator.SetBool("Electric",false);
            animator.SetBool("Fire",false);
            animator.SetBool("Ice",false);
            animator.SetBool("FireTrigger",false);
            iceHolder.SetActive(false);
            fireHolder.SetActive(false);
            electricHolder.SetActive(false);
        }

        characterController.Move(playerVelocity * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(rotationNum == 3)
            {
                rotationNum = 0;
            }
            else
            {
                rotationNum++;
            }
        }
        if(electricPower)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                GameObject projectileObject = Instantiate(electricOrb, transform.position, Quaternion.Euler(0,cameraEulerAngles.y,0));
                ElectricOrb projectile = projectileObject.GetComponent<ElectricOrb>();
                projectile.Launch(moveDirection, 300);
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                GameObject projectileObject = Instantiate(electricOrb, transform.position, Quaternion.Euler(0,cameraEulerAngles.y,0));
                ElectricOrb projectile = projectileObject.GetComponent<ElectricOrb>();
                projectile.Launch(moveDirection, 300);
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                GameObject projectileObject = Instantiate(electricOrb, transform.position, Quaternion.Euler(0,cameraEulerAngles.y,0));
                ElectricOrb projectile = projectileObject.GetComponent<ElectricOrb>();
                projectile.Launch(moveDirection, 300);
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                GameObject projectileObject = Instantiate(electricOrb, transform.position, Quaternion.Euler(0,cameraEulerAngles.y,0));
                ElectricOrb projectile = projectileObject.GetComponent<ElectricOrb>();
                projectile.Launch(moveDirection, 300);
            }
        }
    }

    //rotate player based on the camera angle
    void RotatePlayer()
    {
        Vector3 cameraEulerAngles = cameraTransform.eulerAngles;
        cameraEulerAngles.x = 0f;
        cameraEulerAngles.z = 0f;

        Quaternion targetRotation = Quaternion.Euler(cameraEulerAngles);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationLagSpeed * Time.deltaTime);
    }

    //player jump ability
    void Jump()
    {
        if (isGrounded && Input.GetKey(KeyCode.Space) || isGrounded && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = jumpForce;
            audioSource.PlayOneShot(jumpSound);
        }
    }

    //player sprint
    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && currentStamina > 0 && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            isSprinting = true;
        }
        else if (!Input.GetKey(KeyCode.LeftShift) || currentStamina <= 0)
        {
            isSprinting = false;
        }

        if (isSprinting)
        {
            currentStamina -= sprintDepletionRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }
        else if (currentStamina < maxStamina)
        {
            currentStamina += sprintRechargeRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }
    }

    //rotate the camera with q and e
    void RotateCamera()
    {
        float rotationAngle = 0f;

        if (Input.GetKey(KeyCode.E))
        {
            rotationAngle = -rotationCameraSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            rotationAngle = rotationCameraSpeed * Time.deltaTime;
        }
        else
        {
            rotationAngle = 0f;
        }

        float horizontalInput = Input.GetAxis("RightJoystickHorizontal");
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            rotationAngle = horizontalInput * rotationCameraSpeed * Time.deltaTime;
        }

        if (rotationAngle != 0f)
        {
            cameraTransform.RotateAround(transform.position, Vector3.up, rotationAngle);
        }
    }

    void FixedUpdate()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
    }

    void StartRun()
    {
        animator.SetBool("FireAbility",true);
        animator.SetBool("FireTrigger",false);
    }

    void StopRun()
    {
        animator.SetBool("FireTrigger", true);
        animator.SetBool("StartRun",false);
        animator.SetBool("FireAbility",false);
        animator.SetBool("StopRun",false);
    }

    void recoverIce()
    {
        animator.SetBool("Ice Ability",false);
    }

    void UpdateElectricPower()
    {
        electricPowerBar.fillAmount = electricPowerCurrent/electricPowerMax;
    }
    void UpdateIcePower()
    {
        icePowerBar.fillAmount = icePowerCurrent/icePowerMax;
    }
    void UpdateFirePower()
    {
        firePowerBar.fillAmount = firePowerCurrent/firePowerMax;
    }
}