using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{
    private CharacterController player;
    private Animator animator;

    public bool control = true;

    private bool ruch = true;
    
    void Start()
    {
        player = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ruch = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            ruch = false;
        }

        if (ruch)
        {
            Movement();
        }
        
    }

    private void Movement()
    {
        if (control)
        {
            if (player.isGrounded)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    animator.SetTrigger("Jump");
                }
                
                Vector3 move = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
                Vector3 rotate = new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f) * 4.0f;


                if (move.z > 0)
                {
                    move.z = 2;
                    if (move.z > 0 && Input.GetKey(KeyCode.LeftShift))
                    {
                        move.z = 4;
                    }
                }

                animator.SetFloat("Speed", move.z);
                
                transform.Rotate(rotate);
                
                if (Input.GetKey(KeyCode.S))
                {
                    animator.SetFloat("Speed", -2);
                    
                    
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    animator.SetFloat("Speed", 0);
                   
                }
            }    
            
        }
    }
}
