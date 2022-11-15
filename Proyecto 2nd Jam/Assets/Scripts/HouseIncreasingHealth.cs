using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HouseIncreasingHealth : MonoBehaviour
{
    private GameObject player;
    private float playerHealth;
    private GameObject enemy;
    public bool isSafe;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerHealth>().RestoreHealth(6f);
            isSafe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            isSafe = false;
        }

    }
}
