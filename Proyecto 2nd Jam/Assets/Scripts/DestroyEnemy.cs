using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Axe") && Input.GetMouseButtonDown(0))
        if (collision.gameObject.CompareTag("Axe"))
        {
            Debug.Log("Colisionando");
            Destroy(gameObject);
        }
    }
}
