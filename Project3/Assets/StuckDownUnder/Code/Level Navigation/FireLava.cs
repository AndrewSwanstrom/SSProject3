using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLava : MonoBehaviour
{
    public GameObject lost;
    // Start is called before the first frame update
    void Start()
    {
        lost.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Time.timeScale = 0;
            lost.SetActive(true);
        }
    }
}
