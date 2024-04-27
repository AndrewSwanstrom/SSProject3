using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using Unity.VisualScripting;
using System.ComponentModel;

public class SimpleChase : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    public GameObject win;
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);
    public float EnemeyDistanceRun = 5.0f;
    public GameObject destination_1;
    public GameObject destination_2;
    public GameObject destination_3;
    public GameObject destination_4;
    public GameObject destination_5;
    public GameObject destination_6;
    public GameObject destination_7;
    public GameObject destination_8;
    public GameObject destination_9;
    public float[] playerdistance = new float[8];

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 5f;
        animator = GetComponent<Animator>();
        win.SetActive(false);
        if(PlayerController.fireWin)
        {
            this.gameObject.SetActive(false);
        }
    }


    // Fire enemy run away from player with distance and simple AI navmesh
    void Update()
    {
        float max = 0;
        int index = 0;
        playerdistance[0] = Vector3.Distance(destination_1.transform.position,player.transform.position);
        playerdistance[1] = Vector3.Distance(destination_2.transform.position,player.transform.position);
        playerdistance[2] = Vector3.Distance(destination_3.transform.position,player.transform.position);
        playerdistance[3] = Vector3.Distance(destination_4.transform.position,player.transform.position);
        playerdistance[4] = Vector3.Distance(destination_5.transform.position,player.transform.position);
        playerdistance[5] = Vector3.Distance(destination_6.transform.position,player.transform.position);
        playerdistance[6] = Vector3.Distance(destination_7.transform.position,player.transform.position);
        playerdistance[7] = Vector3.Distance(destination_8.transform.position,player.transform.position);
        for(int i = 0; i < 8;i++) 
        {
            if(playerdistance[i]>max)
            {
                max = playerdistance[i];
                index = i;
            }
        }
        if(index == 0)
        {
            agent.SetDestination(destination_1.transform.position);
            Vector3 dir = (destination_1.transform.position - agent.transform.position).normalized;
            if(dir.x>0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",1);
            }
            else if(dir.x<0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",-1);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",-1);
                animator.SetFloat("LookY",0);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",1);
                animator.SetFloat("LookY",0);
            }
            Debug.Log(dir);
        }
        else if(index == 1)
        {
            agent.SetDestination(destination_2.transform.position);
            Vector3 dir = (destination_2.transform.position - agent.transform.position).normalized;
            Debug.Log(dir);
            if(dir.x>0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",1);
            }
            else if(dir.x<0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",-1);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",-1);
                animator.SetFloat("LookY",0);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",1);
                animator.SetFloat("LookY",0);
            }
        }
        else if(index == 2)
        {
            agent.SetDestination(destination_3.transform.position);
            Vector3 dir = (destination_3.transform.position - agent.transform.position).normalized;
            Debug.Log(dir);
            if(dir.x>0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",1);
            }
            else if(dir.x<0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",-1);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",-1);
                animator.SetFloat("LookY",0);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",1);
                animator.SetFloat("LookY",0);
            }
        }
        else if(index == 3)
        {
            agent.SetDestination(destination_4.transform.position);
            Vector3 dir = (destination_4.transform.position - agent.transform.position).normalized;
            Debug.Log(dir);
            if(dir.x>0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",1);
            }
            else if(dir.x<0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",-1);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",-1);
                animator.SetFloat("LookY",0);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",1);
                animator.SetFloat("LookY",0);
            }
        }
        else if(index == 4)
        {
            agent.SetDestination(destination_5.transform.position);
            Vector3 dir = (destination_5.transform.position - agent.transform.position).normalized;
            Debug.Log(dir);
            if(dir.x>0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",1);
            }
            else if(dir.x<0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",-1);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",-1);
                animator.SetFloat("LookY",0);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",1);
                animator.SetFloat("LookY",0);
            }
        }
        else if(index == 5)
        {
            agent.SetDestination(destination_6.transform.position);
            Vector3 dir = (destination_6.transform.position - agent.transform.position).normalized;
            Debug.Log(dir);
            if(dir.x>0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",1);
            }
            else if(dir.x<0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",-1);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",-1);
                animator.SetFloat("LookY",0);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",1);
                animator.SetFloat("LookY",0);
            }
        }
        else if(index == 6)
        {
            agent.SetDestination(destination_7.transform.position);
            Vector3 dir = (destination_7.transform.position - agent.transform.position).normalized;
            Debug.Log(dir);
            if(dir.x>0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",1);
            }
            else if(dir.x<0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",-1);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",-1);
                animator.SetFloat("LookY",0);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",1);
                animator.SetFloat("LookY",0);
            }
        }
        else if (index == 7)
        {
            agent.SetDestination(destination_8.transform.position);
            Vector3 dir = (destination_8.transform.position - agent.transform.position).normalized;
            Debug.Log(dir);
            if(dir.x>0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",1);
            }
            else if(dir.x<0)
            {
                animator.SetFloat("LookX",0);
                animator.SetFloat("LookY",-1);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",-1);
                animator.SetFloat("LookY",0);
            }
            else if(dir.z>0)
            {
                animator.SetFloat("LookX",1);
                animator.SetFloat("LookY",0);
            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController.fireWin = true;
            this.gameObject.SetActive(false);
        }
    }
}
