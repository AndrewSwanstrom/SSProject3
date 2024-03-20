using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricRestart : MonoBehaviour
{
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        
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
            characterController = other.GetComponent<CharacterController>();
            characterController.enabled = false;
            other.transform.position = new Vector3(-5.659f, 1.97f, 0.269f);
            characterController.enabled = true;
        }
    }
}
