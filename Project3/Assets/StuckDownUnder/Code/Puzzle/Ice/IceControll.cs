using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceControll : MonoBehaviour
{
    public GameObject penguinCharacter;
    public GameObject notifyText;
    public GameObject player;
    CharacterController characterController;
    PlayerController playerController;
    AudioSource audioSource;
    public Camera cam1;
    public Camera cam2;
    Penguin penguin;
    bool playerRange;
    public bool solvePuzzle;
    public AudioClip perriGuide;
    // Start is called before the first frame update
    void Start()
    {
        penguin = penguinCharacter.GetComponent<Penguin>();
        notifyText.SetActive(false);
        playerRange = false;
        solvePuzzle = false;
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        cam1.enabled = true;
        cam2.enabled = false;
        audioSource = player.GetComponent<AudioSource>();
        if(!PlayerController.firstTimeIce)
        {
            PlayerController.firstTimeIce = true;
            audioSource.PlayOneShot(perriGuide);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if player is in range of the mechanic
        if(playerRange)
        {
            //notification shows up
            //if press F the puzzle will begin
            if(Input.GetKey(KeyCode.F)) //|| Input.GetButtonDown("Interact"))
            {
                //penguin.penguinMove = true;
                solvePuzzle = true;
                playerController.enabled = false;
                notifyText.SetActive(false);

            }
            else if(Input.GetKeyDown(KeyCode.Escape)) //|| Input.GetButtonDown("Back"))
            {
                solvePuzzle = false;
                playerController.enabled = true;
            }
        }
        else
        {
            
        }
        if(solvePuzzle)
        {
            cam1.enabled = false;
            cam2.enabled = true;
            notifyText.SetActive(false);
        }
        else
        {
            cam1.enabled = true;
            cam2.enabled = false;
        }
    }

    //if player is in range the trigger will show true
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerRange = true;
            notifyText.SetActive(true);
        }
    }

    //shows false once the player exits the range
    void OnTriggerExit(Collider other)
    {
        if(other.tag =="Player")
        {
            playerRange = false;
            notifyText.SetActive(false);
        }
    }
}
