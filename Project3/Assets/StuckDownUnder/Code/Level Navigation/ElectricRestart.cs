using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricRestart : MonoBehaviour
{
    CharacterController characterController;
    public GameObject gameOver;

    public AudioClip deathSound;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //resets the player position if they fall out of the level
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerController = other.GetComponent<PlayerController>();
            playerController.audioSource.PlayOneShot(deathSound);
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
