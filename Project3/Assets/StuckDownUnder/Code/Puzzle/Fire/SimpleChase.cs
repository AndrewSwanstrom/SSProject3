using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleChase : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    public GameObject win;
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);
    public float EnemeyDistanceRun = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 6.5f;
        animator = GetComponent<Animator>();
        win.SetActive(false);
    }


    // Fire enemy run away from player with distance and simple AI navmesh
    void Update()
    {
        float distance = UnityEngine.Vector3.Distance(transform.position, player.transform.position);

        if(distance<EnemeyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            animator.SetFloat("Look X", dirToPlayer.x);
            animator.SetFloat("Look Y", dirToPlayer.y);

            Vector3 newPos = transform.position + dirToPlayer;

            agent.SetDestination(newPos);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
