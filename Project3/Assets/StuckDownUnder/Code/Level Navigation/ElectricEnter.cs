using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElectricEnter : MonoBehaviour
{
    public GameObject electricEnterText;
    bool sceneEnter;
    // Start is called before the first frame update
    void Start()
    {
        electricEnterText.SetActive(false);
        sceneEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneEnter)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    //Load the Electric Level when the player enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            electricEnterText.SetActive(true);
            sceneEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            electricEnterText.SetActive(false);
            sceneEnter = false;
        }
    }
}
