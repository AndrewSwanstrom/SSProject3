using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    public static bool perma = false;
    public static bool charge = false;
    public static bool staticLevel= false;
    public GameObject textPerma;
    public GameObject textStatic;
    public GameObject textCharge;
    // Start is called before the first frame update
    void Start()
    {
        textPerma.SetActive(false);
        textStatic.SetActive(false);
        textCharge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CheatManager.perma)
        {
            textPerma.SetActive(true);
        }
        else
        {
            textPerma.SetActive(false);
        }
        if(CheatManager.staticLevel)
        {
            textStatic.SetActive(true);
        }
        else
        {
            textStatic.SetActive(false);
        }
        if(CheatManager.charge)
        {
            textCharge.SetActive(true);
        }
        else
        {
            textCharge.SetActive(false);
        }
    }

    public void changePerma()
    {
        if(CheatManager.perma)
        {
            CheatManager.perma = false;
        }
        else
        {
            CheatManager.perma = true;
        }
    }

    public void changeStatic()
    {
        if(CheatManager.staticLevel)
        {
            CheatManager.staticLevel = false;
        }
        else
        {
            CheatManager.staticLevel = true;
        }
    }

    public void changeCharge()
    {
        if(CheatManager.charge)
        {
            CheatManager.charge = false;
        }
        else
        {
            CheatManager.charge = true;
        }
    }
}
