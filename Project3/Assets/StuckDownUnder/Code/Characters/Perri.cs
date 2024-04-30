using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Perri : MonoBehaviour
{
    Animator animator;
    public float rotationLagSpeed = 5f;
    public Transform cameraTransform;
    public GameObject talkActivationText;
    AudioSource audioSource;
    AudioSource backGroundSource;
    PlayerController playerController;
    public AudioClip alive;
    public AudioClip bestFriend;
    public AudioClip leave;
    public AudioClip whispers;
    public AudioClip gates;
    public AudioClip legLess;
    public AudioClip whichItem;
    public AudioClip hereYouGo;
    public GameObject backGroundMusic;
    static int talkSequence = 0;
    bool canTalk;
    float duration;
    private int index;
    private int newIndex;
    static bool firstConvo = false;
    public static bool perriItems = false;
    public GameObject itemSelection;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("aniPlayer",2.0f,5f);
        canTalk = false;
        audioSource = GetComponent<AudioSource>();
        backGroundSource = backGroundMusic.GetComponent<AudioSource>();
        var joinClips = new AudioClip[] {alive, bestFriend, leave, whispers, gates, legLess};
        itemSelection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        if(canTalk)
        {
            if(Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Interact"))
            {
                PlayNote();
            }
            if(!audioSource.isPlaying)
            {
                backGroundSource.volume = 0.5f;
            }
        }
        if(perriItems)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                if(PlayerController.electricWin)
                {

                }
                else if(PlayerController.abilities_held ==0 && !PlayerController.iceWin && !PlayerController.fireWin && !PlayerController.electricWin && PlayerController.rotationMax[1] != 1)
                {
                    PlayerController.rotationMax[1] = 1;
                    PlayerController.abilities_held = 1;
                    PlayerController.rotationMax[2] = 0;
                    PlayerController.rotationMax[3] = 0;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held ==1 && !PlayerController.iceWin && !PlayerController.fireWin && !PlayerController.electricWin && PlayerController.rotationMax[1] != 1)
                {
                    PlayerController.rotationMax[1] = 1;
                    PlayerController.abilities_held = 1;
                    PlayerController.rotationMax[2] = 0;
                    PlayerController.rotationMax[3] = 0;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held ==1 && !PlayerController.electricWin && PlayerController.levelWins == 1)
                {
                    PlayerController.rotationMax[1] = 1;
                    PlayerController.abilities_held = 2;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held == 2 && !PlayerController.electricWin && PlayerController.levelWins == 2 && PlayerController.fireWin && PlayerController.iceWin)
                {
                    PlayerController.rotationMax[1] = 1;
                    PlayerController.abilities_held = 3;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held == 2 && !PlayerController.electricWin && PlayerController.levelWins == 1 && PlayerController.fireWin)
                {
                    PlayerController.rotationMax[1] = 1;
                    PlayerController.abilities_held = 2;
                    PlayerController.rotationMax[2] = 0;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held == 2 && !PlayerController.electricWin && PlayerController.levelWins == 1 && PlayerController.iceWin)
                {
                    PlayerController.rotationMax[1] = 1;
                    PlayerController.abilities_held = 2;
                    PlayerController.rotationMax[3] = 0;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
            }
            else if(Input.GetKeyDown(KeyCode.X))
            {
                if(PlayerController.iceWin)
                {

                }
                else if(PlayerController.abilities_held ==0 && !PlayerController.iceWin && !PlayerController.fireWin && !PlayerController.electricWin && PlayerController.rotationMax[2] != 2)
                {
                    PlayerController.rotationMax[2] = 2;
                    PlayerController.abilities_held = 1;
                    PlayerController.rotationMax[1] = 0;
                    PlayerController.rotationMax[3] = 0;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held ==1 && !PlayerController.iceWin && !PlayerController.fireWin && !PlayerController.electricWin && PlayerController.rotationMax[2] != 2)
                {
                    PlayerController.rotationMax[2] = 2;
                    PlayerController.abilities_held = 1;
                    PlayerController.rotationMax[1] = 0;
                    PlayerController.rotationMax[3] = 0;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held ==1 && !PlayerController.iceWin && PlayerController.levelWins == 1)
                {
                    PlayerController.rotationMax[2] = 2;
                    PlayerController.abilities_held = 2;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held == 2 && !PlayerController.iceWin && PlayerController.levelWins == 2 && PlayerController.fireWin && PlayerController.electricWin)
                {
                    PlayerController.rotationMax[2] = 2;
                    PlayerController.abilities_held = 3;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held == 2 && !PlayerController.iceWin && PlayerController.levelWins == 1 && PlayerController.fireWin)
                {
                    PlayerController.rotationMax[2] = 2;
                    PlayerController.abilities_held = 2;
                    PlayerController.rotationMax[3] = 0;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held == 2 && !PlayerController.iceWin && PlayerController.levelWins == 1 && PlayerController.electricWin)
                {
                    PlayerController.rotationMax[2] = 2;
                    PlayerController.abilities_held = 2;
                    PlayerController.rotationMax[1] = 0;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                
            }
            else if(Input.GetKeyDown(KeyCode.C))
            {
                if(PlayerController.fireWin)
                {

                }
                else if(PlayerController.abilities_held ==0 && !PlayerController.fireWin && !PlayerController.iceWin && !PlayerController.electricWin && PlayerController.rotationMax[3] != 3)
                {
                    PlayerController.rotationMax[3] = 3;
                    PlayerController.abilities_held = 1;
                    PlayerController.rotationMax[1] = 0;
                    PlayerController.rotationMax[2] = 0;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held ==1 && !PlayerController.fireWin && !PlayerController.iceWin && !PlayerController.electricWin && PlayerController.rotationMax[3] != 3)
                {
                    PlayerController.rotationMax[3] = 3;
                    PlayerController.abilities_held = 1;
                    PlayerController.rotationMax[1] = 0;
                    PlayerController.rotationMax[2] = 0;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held ==1 && !PlayerController.fireWin && PlayerController.levelWins == 1)
                {
                    PlayerController.rotationMax[3] = 3;
                    PlayerController.abilities_held = 2;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held == 2 && !PlayerController.fireWin && PlayerController.levelWins == 2 && PlayerController.iceWin && PlayerController.electricWin)
                {
                    PlayerController.rotationMax[3] = 3;
                    PlayerController.abilities_held = 3;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held == 2 && !PlayerController.fireWin && PlayerController.levelWins == 1 && PlayerController.iceWin)
                {
                    PlayerController.rotationMax[3] = 3;
                    PlayerController.abilities_held = 2;
                    PlayerController.rotationMax[2] = 0;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
                else if(PlayerController.abilities_held == 2 && !PlayerController.fireWin && PlayerController.levelWins == 1 && PlayerController.electricWin)
                {
                    PlayerController.rotationMax[3] = 3;
                    PlayerController.abilities_held = 2;
                    PlayerController.rotationMax[1] = 0;
                    audioSource.clip = hereYouGo;
                    audioSource.Play();
                }
            }
            }
        }

    void aniPlayer()
    {
        animator.SetBool("Wave",true);
    }

    public void PlayNote()
    {  
        if(!firstConvo)
        {
            var joinClips = new AudioClip[] {alive, bestFriend, leave, whispers, gates, legLess};
            backGroundSource.volume = 0.1f;
            audioSource.clip = joinClips[index];
            // Play current sound
            // I would rather use PlayOneShot in order to allow multiple concurrent sounds
            audioSource.Play();
            // Increase the index, wrap around if reached end of array
            index = (index + 1) % joinClips.Length;
            if(index==5)
            {
                audioSource.clip = legLess;
                audioSource.Play();
                firstConvo = true;
            }
        }
        else
        {
            backGroundSource.volume = 0.1f;
            audioSource.clip = whichItem;
            audioSource.Play();
            perriItems = true;
        }
    } 

    public void endAni()
    {
        animator.SetBool("Wave",false);
    }

    void RotatePlayer()
    {
        Vector3 cameraEulerAngles = cameraTransform.eulerAngles;
        cameraEulerAngles.x = 0f;
        cameraEulerAngles.z = 0f;

        Quaternion targetRotation = Quaternion.Euler(cameraEulerAngles);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationLagSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            talkActivationText.SetActive(true);
            canTalk = true;
            playerController = other.GetComponent<PlayerController>();
            if(perriItems)
            {
                itemSelection.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            talkActivationText.SetActive(false);
            canTalk = false;
            itemSelection.SetActive(false);
        }
    }
}
