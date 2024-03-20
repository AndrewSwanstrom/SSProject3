using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHubReset : MonoBehaviour
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

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            characterController = other.GetComponent<CharacterController>();
            characterController.enabled = false;
            other.transform.position = new Vector3(0.612f, 0.988f, 3.25f);
            characterController.enabled = true;
        }
    }
}
