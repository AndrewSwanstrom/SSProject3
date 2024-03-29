using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCapture : MonoBehaviour
{
    public GameObject centerObject;
    // Start is called before the first frame update
    void Start()
    {
        var r = centerObject.GetComponent<Renderer>();
        Debug.Log(r.bounds.center);
    }

    // Update is called once per frame
    void Update()
    {   

    }
}
