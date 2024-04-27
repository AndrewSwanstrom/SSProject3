using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject iceCube;
    public GameObject iceDropLocation;
    public static bool once = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.iceTutorial && !once)
        {
            Instantiate(iceCube, iceDropLocation.transform.position, Quaternion.identity);
            Tutorial.once = true;
        }
    }
}
