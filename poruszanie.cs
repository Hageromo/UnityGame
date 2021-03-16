using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poruszanie : MonoBehaviour
{
    
    public float speed = 4f;
    public float sensitivity = 2f;
    
    CharacterController player;

    public GameObject oczy;

    public float skok = 5f;
    float verjump;
    private bool skoczyl;

    private bool ruch= true;
    
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ruch = true;
            
        }else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            ruch = false;
        }

        if (ruch)
        {
            Move();
            
        }
        
    }

    private void Move()
    {
        
        float movept = Input.GetAxis("Vertical") * speed;
        float movepl = Input.GetAxis("Horizontal") * speed;   
        
        float rotx = Input.GetAxis("Mouse X") * sensitivity;
        float roty = Input.GetAxis("Mouse Y") * sensitivity;
        
        Vector3 movement = new Vector3(movepl, verjump, movept);
        
        transform.Rotate(0, rotx, 0);
        oczy.transform.Rotate(-roty, 0, 0);
        
        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump"))
        {
            skoczyl = true;
        }
        
        Gravity();
    }

    private void Gravity()
    {
        if (player.isGrounded)
        {
            if (skoczyl == false)
            {
                verjump = Physics.gravity.y;
            }
            else
            {
                verjump = skok;
            }

        }
        else
        {
            verjump += Physics.gravity.y * Time.deltaTime;
            verjump = Mathf.Clamp(verjump, -50f, skok);
            skoczyl = false;
        }
    }
}
