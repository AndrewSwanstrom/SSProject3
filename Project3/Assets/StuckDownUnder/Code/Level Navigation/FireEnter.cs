using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireEnter : MonoBehaviour
{
    public GameObject electricEnterText;
    bool sceneEnter;
    // Start is called before the first frame update
    void Start()
    {
        electricEnterText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneEnter)
        {
            if(Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Interact"))
            {
                SceneManager.LoadScene(4);
            }
        }
    }

    // Loads the fire level from the main hub when the player steps into the trigger
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
