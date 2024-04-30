using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Tutorial : MonoBehaviour
{
    public GameObject iceCube;
    public GameObject iceDropLocation;
    public static bool once = false;

    public GameObject tutorialTextAll;
    public GameObject tutorialTextIce;
    public GameObject tutorialTextFire;
    public GameObject tutorialTextElectric;
    public bool activation;
    // Start is called before the first frame update
    void Start()
    {
        tutorialTextAll.SetActive(false);
        tutorialTextIce.SetActive(false);
        tutorialTextFire.SetActive(false);
        tutorialTextElectric.SetActive(false);
        activation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(activation)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                tutorialTextElectric.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.X))
            {
                tutorialTextIce.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.C))
            {
                tutorialTextFire.SetActive(true);
            }
        }
        if(PlayerController.iceTutorial && !once)
        {
            Instantiate(iceCube, iceDropLocation.transform.position, Quaternion.identity);
            Tutorial.once = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            tutorialTextAll.SetActive(true);
            activation = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            tutorialTextAll.SetActive(false);
            activation = false;
            tutorialTextIce.SetActive(false);
            tutorialTextFire.SetActive(false);
            tutorialTextElectric.SetActive(false);
        }
    }
}
