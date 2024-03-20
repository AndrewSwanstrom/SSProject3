using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class SimpleChase : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    public float EnemeyDistanceRun = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    // Fire enemy run away from player with distance and simple AI navmesh
    void Update()
    {
        float distance = UnityEngine.Vector3.Distance(transform.position, player.transform.position);

        if(distance<EnemeyDistanceRun)
        {
            UnityEngine.Vector3 dirToPlayer = transform.position - player.transform.position;

            UnityEngine.Vector3 newPos = transform.position + dirToPlayer;

            agent.SetDestination(newPos);
        }
    }
}
