using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Console : MonoBehaviour
{
    public GameObject maze;
    MazeManage mazeManage;
    // Start is called before the first frame update
    void Start()
    {
        maze = GameObject.FindWithTag("Maze");
        mazeManage = maze.GetComponent<MazeManage>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
