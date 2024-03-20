using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceRestart : MonoBehaviour
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

    //reset player position if they fall off the level
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            characterController = other.GetComponent<CharacterController>();
            characterController.enabled = false;
            other.transform.position = new Vector3(0f, 1f, -7f);
            characterController.enabled = true;
        }
    }
}
