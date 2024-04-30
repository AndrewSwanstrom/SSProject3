using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWin : MonoBehaviour
{
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
        if(other.tag == "Penguin")
        {
            other.gameObject.SetActive(false);
            PlayerController.iceWin = true;
            PlayerController.levelWins++;
        }
    }
}
