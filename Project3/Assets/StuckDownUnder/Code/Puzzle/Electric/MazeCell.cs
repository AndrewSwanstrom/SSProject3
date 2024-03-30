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

    public bool IsVisited {get; private set;}

    bool canGenerate = false;

    void Update()
    {
        if(_unvisitedBlock.activeSelf == false && canGenerate == false)
        {
            //Circuit_End Pointing Right
            if(_rightWall.activeSelf == false && _backWall.activeSelf == true && _frontWall.activeSelf == true && _leftWall.activeSelf == true)
            {
                Instantiate(circuit_End, transform.position, Quaternion.identity);
            }
            //Circuit_End Pointing Left
            else if(_leftWall.activeSelf == false && _frontWall.activeSelf == true && _backWall.activeSelf == true && _rightWall.activeSelf == true)
            {
                Instantiate(circuit_End, transform.position, Quaternion.Euler(0,180,0));
            }
            //Circuit_End Point Top
            else if(_frontWall.activeSelf == false && _backWall.activeSelf == true && _rightWall.activeSelf == true && _leftWall.activeSelf == true)
            {
                Instantiate(circuit_End, transform.position, Quaternion.Euler(0,270,0));
            }
            //Circuit_End Point Bottom
            else if(_backWall.activeSelf == false && _frontWall.activeSelf == true && _rightWall.activeSelf == true && _leftWall.activeSelf == true)
            {
                Instantiate(circuit_End, transform.position, Quaternion.Euler(0,90,0));
            }
            //Circuit_Straight Horizontal
            else if(_leftWall.activeSelf == false && _rightWall.activeSelf == false && _frontWall.activeSelf == true && _backWall.activeSelf == true)
            {
                Instantiate(circuit_Straight, transform.position, Quaternion.identity);
            }
            //Circuit_Straight Vertical
            else if(_frontWall.activeSelf == false && _backWall.activeSelf == false && _rightWall.activeSelf == true && _leftWall.activeSelf == true)
            {
                Instantiate(circuit_Straight, transform.position, Quaternion.Euler(0,90,0));
            }
            //Circuit_T Default
            else if(_frontWall.activeSelf == false && _leftWall.activeSelf == false && _rightWall.activeSelf == false && _backWall.activeSelf == true)
            {
                Instantiate(circuit_T, transform.position,Quaternion.identity);
            }
            //Circuit_T Right
            else if(_frontWall.activeSelf == false && _rightWall.activeSelf == false && _backWall.activeSelf == false && _leftWall.activeSelf == true)
            {
                Instantiate(circuit_T, transform.position, Quaternion.Euler(0,90,0));
            }
            //Circuit_T Bottom
            else if(_backWall.activeSelf == false && _rightWall.activeSelf == false && _leftWall.activeSelf == false && _frontWall.activeSelf == true)
            {
                Instantiate(circuit_T, transform.position,Quaternion.Euler(0,180,0));
            }
            //Circuit_T Left
            else if(_frontWall.activeSelf == false && _leftWall.activeSelf == false && _backWall.activeSelf == false && _rightWall.activeSelf == true)
            {
                Instantiate(circuit_T,transform.position,Quaternion.Euler(0,270,0));
            }
            //Circuit_90 Default
            else if(_frontWall.activeSelf == false && _rightWall.activeSelf == false && _backWall.activeSelf == true && _leftWall.activeSelf == true)
            {
                Instantiate(circuit_90, transform.position, Quaternion.identity);
            }
            //Circuit_90 90
            else if(_rightWall.activeSelf == false && _backWall.activeSelf == false && _frontWall.activeSelf == true && _leftWall.activeSelf == true)
            {
                Instantiate(circuit_90, transform.position, Quaternion.Euler(0,90,0));
            }
            //Circuit_90 180
            else if(_backWall.activeSelf == false && _leftWall.activeSelf == false && _rightWall.activeSelf == true && _frontWall.activeSelf == true)
            {
                Instantiate(circuit_90, transform.position, Quaternion.Euler(0,180,0));
            }
            //Circuit_90 270
            else if(_leftWall.activeSelf == false && _frontWall.activeSelf == false && _rightWall.activeSelf == true && _backWall.activeSelf == true)
            {
                Instantiate(circuit_90, transform.position, Quaternion.Euler(0,270,0));
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
