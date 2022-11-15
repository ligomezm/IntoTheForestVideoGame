using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{   
    private NavMeshAgent agent = null;
    GameObject target;
    private HouseIncreasingHealth house;


    void Start()
    {
        GetReferences();
    }


    void Update()
    {
        
        MoveToTarget();        
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.transform.position);

        if (house.isSafe)
        {
            agent.speed = 0;
        }
        else
        {
            agent.speed = 3.5f;
        }

         float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (distanceToTarget <= agent.stoppingDistance)
        {
            RotateToTarget();
        }
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        house = GameObject.FindGameObjectWithTag("House").GetComponent<HouseIncreasingHealth>();
    }

    private void RotateToTarget()
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }
}
