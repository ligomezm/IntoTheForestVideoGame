using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{   
    //GameObject target;
    //float speed;
    private NavMeshAgent agent = null;
    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //speed = 3f;
        //target = GameObject.Find("Player");

        GetReferences();
    }


    void Update()
    {
        /*transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        Vector3 direction = Vector3.RotateTowards(Vector3.forward, target.transform.position - transform.position, 2f, 0f);
        transform.rotation = Quaternion.LookRotation(direction);*/

        MoveToTarget();        
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void RotateToTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }
}
