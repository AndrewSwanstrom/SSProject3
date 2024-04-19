using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brayan : MonoBehaviour
{
    public Transform cameraTransform;
    public float rotationLagSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
    }

    void RotatePlayer()
    {
        Vector3 cameraEulerAngles = cameraTransform.eulerAngles;
        cameraEulerAngles.x = 0f;
        cameraEulerAngles.z = 0f;

        Quaternion targetRotation = Quaternion.Euler(cameraEulerAngles);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationLagSpeed * Time.deltaTime);
    }
}
