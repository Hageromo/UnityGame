using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class poruszanie2 : MonoBehaviour
{ 
    public float speed; 
    public float jump;
    private float sensitivity = 2f;
    public GameObject oczy;
    
    private Rigidbody gracz2;

    private bool ruch = true;
    
    
    public float moverotation = 10.0f;

    void Start()
    {
        gracz2 = GetComponent<Rigidbody>();
        
    }
    
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            ruch = false;
            
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ruch = true;
        }

        if(ruch)
        {
            Move();
            Camera();
            Jump();
        }
        
    }

    public void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        
        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed;

        Vector3 newPosition = gracz2.position + gracz2.transform.TransformDirection(movement);
        
        gracz2.MovePosition(newPosition); 
        
        //obrót postacią za pomoca  MoveRotation
        Quaternion rotateHorizontal = Quaternion.Euler(new Vector3(0.0f, hAxis, 0.0f) * moverotation);
        gracz2.MoveRotation(gracz2.rotation * rotateHorizontal);
    }

    public void Camera()
    {
       // float rotx = Input.GetAxis("Mouse X") * sensitivity;
        float roty = Input.GetAxis("Mouse Y") * sensitivity;
        
       // transform.Rotate(0, rotx, 0);        Mozliwosc obracania kamery w lewo i prawo
        oczy.transform.Rotate(-roty, 0, 0);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gracz2.AddForce(0, jump, 0, ForceMode.Impulse);
        }
    }
    

}
