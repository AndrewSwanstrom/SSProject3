using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IcePuzzleManage : MonoBehaviour
{
    public GameObject[,] iceBlocks = new GameObject[7,7];
    public GameObject[,] markers = new GameObject[7,7];
    public int[,] nums = new int[7,7];
    public GameObject iceCube;
    public Material highLight;
    public Material original;
    public GameObject block_0_1;
    public GameObject block_0_2;
    public GameObject block_0_3;
    public GameObject block_0_4;
    public GameObject block_0_5;
    public GameObject block_1_1;
    public GameObject block_1_2;
    public GameObject block_1_3;
    public GameObject block_1_4;
    public GameObject block_1_5;
    public GameObject block_2_1;
    public GameObject block_2_2;
    public GameObject block_2_3;
    public GameObject block_2_4;
    public GameObject block_2_5;
    public GameObject block_3_0;
    public GameObject block_3_1;
    public GameObject block_3_2;
    public GameObject block_3_3;
    public GameObject block_3_4;
    public GameObject block_3_5;
    public GameObject block_3_6;
    public GameObject block_4_0;
    public GameObject block_4_1;
    public GameObject block_4_2;
    public GameObject block_4_3;
    public GameObject block_4_4;
    public GameObject block_4_5;
    public GameObject block_4_6;
    public GameObject block_5_0;
    public GameObject block_5_1;
    public GameObject block_5_2;
    public GameObject block_5_3;
    public GameObject block_5_4;
    public GameObject block_5_5;
    public GameObject block_5_6;
    public GameObject block_6_0;
    public GameObject block_6_1;
    public GameObject block_6_2;
    public GameObject block_6_3;
    public GameObject block_6_4;
    public GameObject block_6_5;
    public GameObject block_6_6;
    public GameObject iceController;
    public IceControll iceControll;
    public bool penguinStart = false;
    PlayerController playerController;
    public GameObject player;
    int x = 0;
    int y = 1;
    GameObject current;
    GameObject previous;
    // Start is called before the first frame update
    void Start()
    {
        penguinStart = false;
        for(int i = 0; i<7; i++)
        {
            for(int z = 0; z<7; z++)
            {
                nums[i,z] = 0;
            }
        }
        iceBlocks[0,0] = null;
        iceBlocks[0,1] = block_0_1;
        iceBlocks[0,2] = block_0_2;
        iceBlocks[0,3] = block_0_3;
        iceBlocks[0,4] = block_0_4;
        iceBlocks[0,5] = block_0_5;
        iceBlocks[0,6] = null;
        iceBlocks[1,0] = null;
        iceBlocks[1,1] = block_1_1;
        iceBlocks[1,2] = block_1_2;
        iceBlocks[1,3] = block_1_3;
        iceBlocks[1,4] = block_1_4;
        iceBlocks[1,5] = block_1_5;
        iceBlocks[1,6] = null;
        iceBlocks[2,0] = null;
        iceBlocks[2,1] = block_2_1;
        iceBlocks[2,2] = block_2_2;
        iceBlocks[2,3] = block_2_3;
        iceBlocks[2,4] = block_2_4;
        iceBlocks[2,5] = block_2_5;
        iceBlocks[2,6] = null;
        iceBlocks[3,0] = block_3_0;
        iceBlocks[3,1] = block_3_1;
        iceBlocks[3,2] = block_3_2;
        iceBlocks[3,3] = block_3_3;
        iceBlocks[3,4] = block_3_4;
        iceBlocks[3,5] = block_3_5;
        iceBlocks[3,6] = block_3_6;
        iceBlocks[4,0] = block_4_0;
        iceBlocks[4,1] = block_4_1;
        iceBlocks[4,2] = block_4_2;
        iceBlocks[4,3] = block_4_3;
        iceBlocks[4,4] = block_4_4;
        iceBlocks[4,5] = block_4_5;
        iceBlocks[4,6] = block_4_6;
        iceBlocks[5,0] = block_5_0;
        iceBlocks[5,1] = block_5_1;
        iceBlocks[5,2] = block_5_2;
        iceBlocks[5,3] = block_5_3;
        iceBlocks[5,4] = block_5_4;
        iceBlocks[5,5] = block_5_5;
        iceBlocks[5,6] = block_5_6;
        iceBlocks[6,0] = block_6_0;
        iceBlocks[6,1] = block_6_1;
        iceBlocks[6,2] = block_6_2;
        iceBlocks[6,3] = block_6_3;
        iceBlocks[6,4] = block_6_4;
        iceBlocks[6,5] = block_6_5;
        iceBlocks[6,6] = block_6_6;
        iceController = GameObject.FindWithTag("IceController");
        iceControll = iceController.GetComponent<IceControll>();
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!penguinStart && playerController.icePuzzle)
        {
            for(int i = 0; i<7; i++)
            {
                for(int z = 0; z<7; z++)
                {
                    if(nums[i,z] == 1)
                    {
                        markers[i,z] = Instantiate(iceCube, new Vector3(iceBlocks[i,z].transform.position.x,8,iceBlocks[i,z].transform.position.z), Quaternion.identity);
                    }
                }
            }
            penguinStart = true;
        }
        if(iceControll.solvePuzzle)
        {
            current = iceBlocks[x,y];
            previous = current;
            current.GetComponentInChildren<MeshRenderer>().material = highLight;
            for(int i = 0; i<7; i++)
            {
                for(int z = 0; z<7; z++)
                {
                    if(nums[i,z] == 1)
                    {
                        iceBlocks[i,z].GetComponentInChildren<MeshRenderer>().material = highLight;
                    }
                }
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                if(y==1 && x==0)
                {
                    y = 5;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else if(y==1 && x==1)
                {
                    y = 5;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else if(y==1 && x==2)
                {
                    y = 5;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else if(y==0)
                {
                    y = 6;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else
                {
                    y--;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                if(y==5 && x==0)
                {
                    y = 1;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else if(y==5 && x==1)
                {
                    y = 1;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else if(y==5 && x==2)
                {
                    y = 1;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else if(y==6)
                {
                    y = 0;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else
                {
                    y++;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
            }
            else if(Input.GetKeyDown(KeyCode.W))
            {
                if(x==6)
                {
                    x = 0;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else
                {
                    x++;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                if(x==0)
                {
                    x = 6;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else if(x==3 && y==6)
                {
                    x = 6;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else if(x==3 && y==0)
                {
                    x = 6;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
                else
                {
                    x--;
                    previous.GetComponentInChildren<MeshRenderer>().material = original;
                    current = iceBlocks[x,y];
                    current.GetComponentInChildren<MeshRenderer>().material = highLight;
                    previous = current;
                }
            }
            else if(Input.GetKeyDown(KeyCode.Return))
            {
                if(x==0 && y == 5)
                {
                    Debug.Log("Nothing");
                }
                else if(x==2 && y == 3)
                {
                    Debug.Log("Nothing");
                }
                else if(x==2 && y == 4)
                {
                    Debug.Log("Nothing");
                }
                else if(x==3 && y == 3)
                {
                    Debug.Log("Nothing");
                }
                else if(x==3 && y == 4)
                {
                    Debug.Log("Nothing");
                }
                else if(x==4 && y == 3)
                {
                    Debug.Log("Nothing");
                }
                else if(x==4 && y == 4)
                {
                    Debug.Log("Nothing");
                }
                else if(nums[x,y] == 1)
                {
                    nums[x,y] = 0;
                    iceBlocks[x,y].GetComponentInChildren<MeshRenderer>().material = original;
                }
                else
                {
                    iceBlocks[x,y].GetComponentInChildren<MeshRenderer>().material = highLight;
                    nums[x,y] = 1;
                }
            }
        }
        else if(!iceControll.solvePuzzle)
        {
            for(int i = 0; i<7; i++)
            {
                for(int z = 0; z<7; z++)
                {
                    if(nums[i,z] == 0)
                    {
                        iceBlocks[i,z].GetComponentInChildren<MeshRenderer>().material = original;
                    }
                }
            }
        }
    }
}
