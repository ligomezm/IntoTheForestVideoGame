using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HouseIncreasingHealth : MonoBehaviour
{
    private GameObject player;
    private float playerHealth;
    private GameObject enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = player.GetComponent<PlayerHealth>().health;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //   if (other.gameObject.CompareTag("Player"))
    //   {
    //      player.GetComponent<PlayerHealth>().RestoreHealth(6f);
    //  }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerHealth>().RestoreHealth(6f);
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
        }

    }
}
