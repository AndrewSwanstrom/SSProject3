using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System;

public class MazeManage : MonoBehaviour
{
    public GameObject[,] circuits = new GameObject[5,5];

    public Vector3 [,] correctRotates = new Vector3[5,5];

    public bool [,] rotateCorrect = new bool [5,5];
    public Material highLight;
    public Material original;
    ElectricPuzzleStart electricPuzzleStart;
    public GameObject consoleTrigger;
    GameObject previous;
    GameObject current;
    int x = 0;
    int z = 0;
    int y = 0;
    int k = 0;
    int a = 0;
    int b = 0;
    int c = 0;
    int d = 0;
    int isDone = 0;
    public AudioClip buzzer;
    AudioSource buzzerSound;
    public GameObject buzzerObject;
    bool buzzerActivate = false;
    public bool winCondition = false;
    // Start is called before the first frame update
    void Start()
    {
        consoleTrigger = GameObject.FindWithTag("ConsoleTrigger");
        buzzerObject = GameObject.FindWithTag("Buzzer");
        buzzerSound = buzzerObject.GetComponent<AudioSource>();
        electricPuzzleStart = consoleTrigger.GetComponent<ElectricPuzzleStart>();
        buzzerActivate = false;
        for(a = 0; a < 5; a++)
        {
            for(b = 0; b < 5; b++)
            {
                rotateCorrect[a,b] = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(electricPuzzleStart.solvePuzzle == true)
        {
            current = circuits[x,z];
            previous = current;
            var cTag = current.tag;
            current.GetComponentInChildren<MeshRenderer>().material = highLight;
            if(Input.GetKeyDown(KeyCode.F) && cTag!="End" || Input.GetButtonDown("Interact") && cTag!="End")
            {
                current.transform.Rotate(0,90,0);
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                if(z==4)
                {
                    z = 0;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = circuits[x,z];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else
                {
                    z++;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = circuits[x,z];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                if(z==0)
                {
                    z = 4;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = circuits[x,z];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else
                {
                    z--;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = circuits[x,z];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
            }
            else if(Input.GetKeyDown(KeyCode.W))
            {
                if(x==4)
                {
                    x = 0;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = circuits[x,z];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else
                {
                    x++;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = circuits[x,z];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                if(x==0)
                {
                    x = 4;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = circuits[x,z];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else
                {
                    x--;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = circuits[x,z];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
            }
            for(y = 0; y < 5; y++)
            {
                for(k = 0; k < 5; k++)
                {
                    var isStraight = circuits[y,k].tag;
                    if(isStraight == "Straight")
                    {
                        if(correctRotates[y,k].y == 0 || correctRotates[y,k].y == 180)
                        {
                            if((int)circuits[y,k].transform.eulerAngles.y == 0 || (int)circuits[y,k].transform.eulerAngles.y == 180)
                            {
                                rotateCorrect[y,k] = true;
                            }
                            else
                            {
                                rotateCorrect[y,k] = false;
                            }
                        }
                        else if((int)correctRotates[y,k].y == 90 || (int)correctRotates[y,k].y == 270)
                        {
                            if((int)circuits[y,k].transform.eulerAngles.y == 90 || (int)circuits[y,k].transform.eulerAngles.y == 270)
                            {
                                rotateCorrect[y,k] = true;
                            }
                            else
                            {
                                rotateCorrect[y,k] = false;
                            }
                        }
                    }
                    else if((int)circuits[y,k].transform.eulerAngles.y == (int)correctRotates[y,k].y)
                    {
                        rotateCorrect[y,k] = true;
                    }
                    else
                    {
                        rotateCorrect[y,k] = false;
                    }
                }
            }
            isDone = 0;
            for(c = 0; c<5; c++)
            {
                for(d = 0; d < 5; d++)
                {
                    if(rotateCorrect[c,d] == false)
                    {
                        isDone++;
                    }
                }
            }
            if(isDone == 0 && !buzzerActivate)
            {
                buzzerSound.PlayOneShot(buzzer);
                buzzerActivate = true;
                winCondition = true;
            }
            else if(isDone != 0 && buzzerActivate)
            {
                buzzerActivate = false;
                winCondition = false;
            }
        }
    }
}
