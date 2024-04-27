using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 move = new Vector3(-1,0,0);
    private float penguinSpeed = 3f;
    public bool penguinMove = false;
    IcePuzzleManage icePuzzleManage;
    public GameObject iceManager;
    Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        iceManager = GameObject.FindWithTag("IceManager");
        characterController = GetComponent<CharacterController>();
        icePuzzleManage = iceManager.GetComponent<IcePuzzleManage>();
        penguinMove = false;
        if(PlayerController.iceWin)
        {
            this.gameObject.SetActive(false);
        }
        animator = GetComponent<Animator>();
        if(PlayerController.iceWin)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(move);
        if(icePuzzleManage.penguinStart)
        {
            StartCoroutine(PenguinDelay());
            if(penguinMove)
            {
                characterController.Move(move * Time.deltaTime * penguinSpeed);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "IceCube")
        {
            Debug.Log("Hello");
            if(move == new Vector3(1,0,0))
            {
                move = new Vector3(0,0,-1);
                animator.SetFloat("LookX", 0);
                animator.SetFloat("LookY", -1);
            }
            else if(move == new Vector3(0,0,-1))
            {
                move = new Vector3(-1,0,0);
                animator.SetFloat("LookX", -1);
                animator.SetFloat("LookY", 0);
            }
            else if(move == new Vector3(-1,0,0))
            {
                move = new Vector3(0,0,1);
                animator.SetFloat("LookX", 0);
                animator.SetFloat("LookY", 1);
            }
            else if(move == new Vector3(0,0,1))
            {
                move = new Vector3(1,0,0);
                animator.SetFloat("LookX", 1);
                animator.SetFloat("LookY", 0);
            }
            
        }
        else if(other.tag == "FinalIce")
        {
            
        }
    }

    private IEnumerator PenguinDelay() {
     yield return new WaitForSeconds(5f);
     penguinMove = true;
}
}
