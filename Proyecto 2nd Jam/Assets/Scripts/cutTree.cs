using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutTree : MonoBehaviour
{
    public int life;
    //public bool isCut;
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;

     private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag ("Axe"))
        {
            Destroy(gameObject);
            cantidadPuntos++;
            puntaje.SumarPuntos(cantidadPuntos);
        }

     }

    // Update is called once per frame
    /*void Update()
    {
        
        if (isCut) 
        {

        life = life - 5;
        if (life <= 0)
            {
             Destroy(this.gameObject);
             life = 50;
            }

         }
       Debug.Log(life);
    }*/
}