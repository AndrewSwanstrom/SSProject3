using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerController.fireWin || CheatManager.staticLevel)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && PlayerController.fireAbility)
        {
            this.gameObject.SetActive(false);
        }
    }
}
