using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    private CharacterController characterController;
    public UnityEngine.Vector3 move = new UnityEngine.Vector3(-1,0,0);
    private float penguinSpeed = 5.0f;
    public bool penguinMove = false;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        penguinMove = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(penguinMove)
        {
            characterController.Move(move * Time.deltaTime * penguinSpeed);
        }
    }
}
