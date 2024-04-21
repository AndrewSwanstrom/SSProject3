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
    public GameObject backGroundMusic;
    static int talkSequence = 0;
    bool canTalk;
    float duration;
    private int index;
    static bool firstConvo = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("aniPlayer",2.0f,5f);
        canTalk = false;
        audioSource = GetComponent<AudioSource>();
        backGroundSource = backGroundMusic.GetComponent<AudioSource>();
        var joinClips = new AudioClip[] {alive, bestFriend, leave, whispers};
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        if(canTalk)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                PlayNote();
            }
            if(!audioSource.isPlaying)
            {
                backGroundSource.volume = 0.5f;
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
            var joinClips = new AudioClip[] {alive, bestFriend, leave, whispers};
            backGroundSource.volume = 0.1f;
            audioSource.clip = joinClips[index];
            // Play current sound
            // I would rather use PlayOneShot in order to allow multiple concurrent sounds
            audioSource.Play();
            // Increase the index, wrap around if reached end of array
            index = (index + 1) % joinClips.Length;
            if(index==4)
            {
                firstConvo = true;
            }
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            talkActivationText.SetActive(false);
            canTalk = false;
        }
    }
}
