using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutTree : MonoBehaviour
{
    //public int life;
    public bool isCut;
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;
    public FPSController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();

    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag ("Axe"))
        {
            isCut = true;
        }

     }

    void Update()
    {
        
        if (isCut && player.isAttacking) 
        {

            Destroy(this.gameObject);
            cantidadPuntos++;
            puntaje.AddPoints(cantidadPuntos);

        }

    }
}