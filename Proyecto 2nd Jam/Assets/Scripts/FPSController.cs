using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour

{
    CharacterController characterController;

    public float walkSpeed = 6.0f;
    public float runSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public cutTree lifetree;
    public Animator axe;
    int woodcount;
    private Vector3 move = Vector3.zero;
    [SerializeField] private TextMeshProUGUI firewoodText;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
             
             if (Input.GetKey(KeyCode.LeftShift))
                 move = transform.TransformDirection(move) * runSpeed;
             else
                 move = transform.TransformDirection(move) * walkSpeed;

            if (Input.GetKey(KeyCode.Space))
                move.y = jumpSpeed;
                
        }

        
        if (Input.GetMouseButtonDown(0))
        {
         axe.SetBool("cutting", true);
        }
        else {
        axe.SetBool("cutting", false);
         }
        
        move.y -= gravity * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
        
        
    }

    void Woodcounter()
    {
        if (lifetree.life <= 0)
        {
            woodcount = woodcount + 1;
            firewoodText.text = "Firewood pieces: " + woodcount + "/15";
        }

    }

}
