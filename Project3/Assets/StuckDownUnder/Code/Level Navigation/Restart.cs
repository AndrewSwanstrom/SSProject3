using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
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

    // reset player position if they fall off the fire level
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            characterController = other.GetComponent<CharacterController>();
            characterController.enabled = false;
            other.transform.position = new Vector3(-7.65f, 0.997f, 1.24f);
            characterController.enabled = true;
        }
    }
}
