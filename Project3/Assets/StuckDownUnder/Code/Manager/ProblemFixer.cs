using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemFixer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerController.rotationMax[1]);
        Debug.Log(PlayerController.rotationMax[2]);
        Debug.Log(PlayerController.rotationMax[3]);
    }
}
