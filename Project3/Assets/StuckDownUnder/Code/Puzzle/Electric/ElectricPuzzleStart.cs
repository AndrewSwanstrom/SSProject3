using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPuzzleStart : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public GameObject winScreen;
    public GameObject instructionText;
    public GameObject buttonPress;
    CharacterController characterController;
    PlayerController playerController;
    public GameObject player;
    public bool activation = false;
    public bool solvePuzzle = false;
    public GameObject Objectives;
    public GameObject Placeholders;
    public GameObject maze;
    MazeManage mazeManage;
    public bool startTheCog = false;
    public GameObject CrankSound;
    AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        instructionText.SetActive(false);
        buttonPress.SetActive(false);
        activation = false;
        solvePuzzle = false;
        playerController = player.GetComponent<PlayerController>();
        maze = GameObject.FindWithTag("Maze");
        mazeManage = maze.GetComponent<MazeManage>();
        startTheCog = false;
        CrankSound.SetActive(false);
        audioSource = player.GetComponent<AudioSource>();
        if(!PlayerController.firstTimeElectric)
        {
            audioSource.PlayOneShot(audioClip);
            PlayerController.firstTimeElectric = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(startTheCog)
        {
            StartCoroutine(SwitchCamera());
        }
        if(activation)
        {
            if(Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Interact"))
            {
                solvePuzzle = true;
                playerController.enabled = false;
                buttonPress.SetActive(false);
                Objectives.SetActive(false);
                Placeholders.SetActive(false);
            }
            else if(Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Back"))
            {
                solvePuzzle = false;
                playerController.enabled = true;
                buttonPress.SetActive(true);
                Objectives.SetActive(true);
                Placeholders.SetActive(true);
            }
        }
        if(solvePuzzle)
        {
            cam1.enabled = false;
            cam2.enabled = true;
            instructionText.SetActive(true);
        }
        else
        {
            cam1.enabled = true;
            cam2.enabled = false;
            instructionText.SetActive(false);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            activation = true;
            buttonPress.SetActive(true);
        }
        else if(other.tag == "Orb" && mazeManage.winCondition)
        {
            cam1.enabled = false;
            cam3.enabled = true;
            CrankSound.SetActive(true);
            startTheCog = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            activation = false;
            buttonPress.SetActive(false);
        }
    }
    private IEnumerator SwitchCamera() {
     yield return new WaitForSeconds(5f);
     cam1.enabled = true;
     cam3.enabled = false;
     winScreen.SetActive(true);
     Time.timeScale = 0;
}
}
