using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutTree : MonoBehaviour
{
    public int life;
    public bool isCut;

     private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag ("Axe"))
        {
            isCut = true;
        
         }

        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (isCut) {

        life = life - 5;
        if (life <= 0){
           life = 50;

         }

         }
       Debug.Log(life);
    }
}
