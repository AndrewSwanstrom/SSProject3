using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

    Animator animator;

    Vector2 lookDirection = new Vector2(1,0);

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool isSprinting;
    public float currentStamina;

    public Transform cameraTransform;
    bool isElectric;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentStamina = maxStamina;
        animator = GetComponent<Animator>();
        isElectric = false;
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
        Jump();
        Sprint();
        RotateCamera();
    }

    //player movement
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontalInput, verticalInput);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        if(Input.GetKeyDown(KeyCode.R) && !isElectric)
        {
            animator.SetBool("Electric", true);
            isElectric = true;
        }
        else if(Input.GetKeyDown(KeyCode.R) && isElectric)
        {
            animator.SetBool("Electric",false);
            isElectric = false;
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

        characterController.Move(playerVelocity * Time.deltaTime);
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
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            playerVelocity.y = jumpForce;
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
}