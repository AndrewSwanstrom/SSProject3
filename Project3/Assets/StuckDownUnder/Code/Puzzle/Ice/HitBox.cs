using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    Penguin penguin;

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
            penguin = other.GetComponent<Penguin>();
            if(penguin.move == new UnityEngine.Vector3(1,0,0))
            {
                penguin.move = new UnityEngine.Vector3(0,0,-1);
            }
            else if(penguin.move == new UnityEngine.Vector3(0,0,-1))
            {
                penguin.move = new UnityEngine.Vector3(-1,0,0);
            }
            else if(penguin.move == new UnityEngine.Vector3(-1,0,0))
            {
                penguin.move = new UnityEngine.Vector3(0,0,1);
            }
            else if(penguin.move == new UnityEngine.Vector3(0,0,1))
            {
                penguin.move = new UnityEngine.Vector3(1,0,0);
            }
        }
    }
}
