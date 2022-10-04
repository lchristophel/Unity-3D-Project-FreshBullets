using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string checkpointName;
    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animator;
    private bool canMove = false;

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GameObject checkpoint = GameObject.Find(checkpointName);
        target = checkpoint.transform;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();
        animator.SetBool("IsWalking", true);
        agent.destination = target.position;
    }


    void Update()
    {
        if (agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete && agent.remainingDistance <= .5f)
        {
            animator.SetBool("IsWalking", false);
            if (canMove == false)
            {
                canMove = true;
                setNewDestination("Checkpoint2");
            }
        }
    }

    void setNewDestination(string destination)
    {
        checkpointName = destination;
        GameObject checkpoint = GameObject.Find(checkpointName);
        target = checkpoint.transform;
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();
        animator.SetBool("IsWalking", true);
        agent.destination = target.position;
    }
}
