using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject _leftWall;

    [SerializeField]
    private GameObject _rightWall;

    [SerializeField]
    private GameObject _frontWall;

    [SerializeField]
    private GameObject _backWall;

    [SerializeField]
    private GameObject _unvisitedBlock;

    public GameObject circuit_90;
    public GameObject circuit_T;
    public GameObject circuit_End;
    public GameObject circuit_Straight;
    MazeManage mazeManage;
    public GameObject Maze;

    Console console;
    public GameObject consoleControls;

    public bool IsVisited {get; private set;}

    bool canGenerate = false;
    Vector3 currentRotation;

    Vector3 correctRotation;

    public float[] rotateNums;

    bool canSend;

    void Start()
    {
        canSend = true;
        rotateNums = new float[4];
        rotateNums[0] = 0;
        rotateNums[1] = 90;
        rotateNums[2] = 180;
        rotateNums[3] = 270;
        consoleControls = GameObject.FindWithTag("Console");
        console = consoleControls.GetComponent<Console>();
        Maze = GameObject.FindWithTag("Maze");
        mazeManage = Maze.GetComponent<MazeManage>();
    }
    void Update()
    {
        if(_unvisitedBlock.activeSelf == false && canGenerate == false)
        {
            //Circuit_End Pointing Right
            if(_rightWall.activeSelf == false && _backWall.activeSelf == true && _frontWall.activeSelf == true && _leftWall.activeSelf == true)
            {
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_End, transform.position, Quaternion.Euler(0,0,0));
                correctRotation = new Vector3(0,0,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_End Pointing Left
            else if(_leftWall.activeSelf == false && _frontWall.activeSelf == true && _backWall.activeSelf == true && _rightWall.activeSelf == true)
            {
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_End, transform.position, Quaternion.Euler(0,180,0));
                correctRotation = new Vector3(0,180,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_End Point Top
            else if(_frontWall.activeSelf == false && _backWall.activeSelf == true && _rightWall.activeSelf == true && _leftWall.activeSelf == true)
            {
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_End, transform.position, Quaternion.Euler(0,270,0));
                correctRotation = new Vector3(0,270,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_End Point Bottom
            else if(_backWall.activeSelf == false && _frontWall.activeSelf == true && _rightWall.activeSelf == true && _leftWall.activeSelf == true)
            {
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_End, transform.position, Quaternion.Euler(0,90,0));
                correctRotation = new Vector3(0,90,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_Straight Horizontal
            else if(_leftWall.activeSelf == false && _rightWall.activeSelf == false && _frontWall.activeSelf == true && _backWall.activeSelf == true)
            {
                var index = UnityEngine.Random.Range(0,rotateNums.Length);
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_Straight, transform.position, Quaternion.Euler(0,rotateNums[index],0));
                correctRotation = new Vector3(0,0,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_Straight Vertical
            else if(_frontWall.activeSelf == false && _backWall.activeSelf == false && _rightWall.activeSelf == true && _leftWall.activeSelf == true)
            {
                var index = UnityEngine.Random.Range(0,rotateNums.Length);
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_Straight, transform.position, Quaternion.Euler(0,rotateNums[index],0));
                correctRotation = new Vector3(0,90,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_T Default
            else if(_frontWall.activeSelf == false && _leftWall.activeSelf == false && _rightWall.activeSelf == false && _backWall.activeSelf == true)
            {
                var index = UnityEngine.Random.Range(0,rotateNums.Length);
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_T, transform.position,Quaternion.Euler(0,rotateNums[index],0));
                correctRotation = new Vector3(0,0,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_T Right
            else if(_frontWall.activeSelf == false && _rightWall.activeSelf == false && _backWall.activeSelf == false && _leftWall.activeSelf == true)
            {
                var index = UnityEngine.Random.Range(0,rotateNums.Length);
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_T, transform.position, Quaternion.Euler(0,rotateNums[index],0));
                correctRotation = new Vector3(0,90,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_T Bottom
            else if(_backWall.activeSelf == false && _rightWall.activeSelf == false && _leftWall.activeSelf == false && _frontWall.activeSelf == true)
            {
                var index = UnityEngine.Random.Range(0,rotateNums.Length);
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_T, transform.position,Quaternion.Euler(0,rotateNums[index],0));
                correctRotation = new Vector3(0,180,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_T Left
            else if(_frontWall.activeSelf == false && _leftWall.activeSelf == false && _backWall.activeSelf == false && _rightWall.activeSelf == true)
            {
                var index = UnityEngine.Random.Range(0,rotateNums.Length);
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_T,transform.position,Quaternion.Euler(0,rotateNums[index],0));
                correctRotation = new Vector3(0,270,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_90 Default
            else if(_frontWall.activeSelf == false && _rightWall.activeSelf == false && _backWall.activeSelf == true && _leftWall.activeSelf == true)
            {
                var index = UnityEngine.Random.Range(0,rotateNums.Length);
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_90, transform.position, Quaternion.Euler(0,rotateNums[index],0));
                correctRotation = new Vector3(0,0,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_90 90
            else if(_rightWall.activeSelf == false && _backWall.activeSelf == false && _frontWall.activeSelf == true && _leftWall.activeSelf == true)
            {
                var index = UnityEngine.Random.Range(0,rotateNums.Length);
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_90, transform.position, Quaternion.Euler(0,rotateNums[index],0));
                correctRotation = new Vector3(0,90,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_90 180
            else if(_backWall.activeSelf == false && _leftWall.activeSelf == false && _rightWall.activeSelf == true && _frontWall.activeSelf == true)
            {
                var index = UnityEngine.Random.Range(0,rotateNums.Length);
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_90, transform.position, Quaternion.Euler(0,rotateNums[index],0));
                correctRotation = new Vector3(0,180,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            //Circuit_90 270
            else if(_leftWall.activeSelf == false && _frontWall.activeSelf == false && _rightWall.activeSelf == true && _backWall.activeSelf == true)
            {
                var index = UnityEngine.Random.Range(0,rotateNums.Length);
                mazeManage.circuits[(int)transform.position.x,(int)transform.position.z] = Instantiate(circuit_90, transform.position, Quaternion.Euler(0,rotateNums[index],0));
                correctRotation = new Vector3(0,270,0);
                mazeManage.correctRotates[(int)transform.position.x,(int)transform.position.z] = correctRotation;
            }
            canGenerate = true;
        }
    }

    public void Visit()
    {
        IsVisited = true;
        _unvisitedBlock.SetActive(false);
    }

    public void ClearLeftWall()
    {
        _leftWall.SetActive(false);
    }

    public void ClearRightWall()
    {
        _rightWall.SetActive(false);
    }

    public void ClearFrontWall()
    {
        _frontWall.SetActive(false);
    }

    public void ClearBackWall()
    {
        _backWall.SetActive(false);
    }
}
