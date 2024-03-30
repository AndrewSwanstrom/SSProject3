using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    public int puzzleCount;
    // Start is called before the first frame update
    void Start()
    {
        puzzleCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(puzzleCount);
    }
}
