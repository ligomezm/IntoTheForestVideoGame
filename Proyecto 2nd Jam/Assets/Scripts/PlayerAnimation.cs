using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("cutting", true);
            
        }
        else 
        {
            anim.SetBool("cutting", false);
        }

    }
}
