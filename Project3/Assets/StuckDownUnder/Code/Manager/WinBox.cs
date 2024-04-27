using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBox : MonoBehaviour
{
    public GameObject fire;
    public GameObject ice;
    public GameObject electric;
    public GameObject isTime;
    public GameObject winScreen;
    public bool isDone = false;
    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);
        ice.SetActive(false);
        electric.SetActive(false);
        isTime.SetActive(false);
        winScreen.SetActive(false);
        isDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDone)
        {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    isTime.SetActive(true);
                    winScreen.SetActive(true);
                }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(!PlayerController.fireWin)
            {
                fire.SetActive(true);
            }
            if(!PlayerController.iceWin)
            {
                ice.SetActive(true);
            }
            if(!PlayerController.electricWin)
            {
                electric.SetActive(true);
            }
            if(PlayerController.electricWin && PlayerController.iceWin && PlayerController.fireWin)
            {
                isTime.SetActive(true);
                isDone = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag =="Player")
        {
            fire.SetActive(false);
            ice.SetActive(false);
            electric.SetActive(false);
            isTime.SetActive(false);
            isDone = false;
        }
    }
}
