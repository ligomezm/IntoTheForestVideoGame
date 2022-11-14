using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDecreasingPlayerLife : MonoBehaviour
{
    private Transform player;
    private float dist;
    public float howClose;
      
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= howClose)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(0.02f);
        }

    }
}
