using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public FPSController player;
    public bool isRange;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (collision.gameObject.CompareTag("Axe") && Input.GetMouseButtonDown(0))
        if (other.gameObject.CompareTag("Axe"))
        {
            //Debug.Log("Colisionando");
            isRange = true;
        }
    }

    private void Update()
    {
        if (isRange && player.isAttacking)
        {
            Destroy(this.gameObject);
        }
    }
}
