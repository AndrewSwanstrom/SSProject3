using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    public GameObject fire;
    public GameObject ice;
    public GameObject electric;
    public GameObject isTime;
    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);
        ice.SetActive(false);
        electric.SetActive(false);
        isTime.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }
}
