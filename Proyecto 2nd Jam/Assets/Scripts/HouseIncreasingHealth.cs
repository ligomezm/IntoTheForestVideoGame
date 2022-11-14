using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseIncreasingHealth : MonoBehaviour
{
    private Transform player;
    private float playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>().health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerHealth>().RestoreHealth(6f);
        }
    }
   
}
