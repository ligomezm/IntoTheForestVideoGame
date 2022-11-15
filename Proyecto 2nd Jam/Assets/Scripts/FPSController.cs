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

    public Transform soldier;
    public Transform[] spawnPoints;
    public float spawnTime;

    public bool isAttacking;
    int enemyCount;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

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
            if (Input.GetMouseButton(0))
            {
                isAttacking = true;
            }
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isAttacking = false;
        }
        else 
        {
        axe.SetBool("cutting", false);
            
        }
        
        move.y -= gravity * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);

        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0 && enemyCount < 6)
        {
            Instantiate(soldier, spawnPoints[Random.Range(0, spawnPoints.Length)].position, spawnPoints[0].rotation);
            spawnTime = 10f;
            enemyCount = enemyCount + 1;
        }
        else if (enemyCount >= 6)
        {
            spawnTime = 60f;
            enemyCount = 0;
        }

    }

}
