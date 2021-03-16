using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject item;
    public GameObject bron;
    public GameObject bron1;
    
    public CharacterController player;
    
    public float distance;

    private bool having = false;

    GameObject bullet;
    
    void Start()
    {
        player = GetComponent<CharacterController>();
        bullet = Resources.Load("pocisk") as GameObject;
        
    }

    
    void Update()
    {
        if (having == false)
        {
            Pick();
        }

        if (having == true)
        {
            Drop();
            Hit();
            
            if (Input.GetKey(KeyCode.C))
            {
                having = false;
                
            }
            
        }
    }

    private void Pick()
    {
        if (Vector3.Distance(player.transform.position, bron.transform.position) < distance)
        {
            item = bron;
            item.SetActive(false);
            having = true;
            
        }
        
        if (Vector3.Distance(player.transform.position, bron1.transform.position) < distance)
        {
            item = bron1;
            item.SetActive(false);
            having = true;
        }
    }

    private void Drop()
    {
        if (Input.GetKey(KeyCode.X))
        {
            item.transform.position = new Vector3(player.transform.position.x + 0.5f,player.transform.position.y + 0.2f,player.transform.position.z + 0.5f);
            item.SetActive(true);
            
        }

    }

    private void Hit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject pocisk = Instantiate(bullet);
            pocisk.transform.position = transform.position + player.transform.up + player.transform.forward;

            Rigidbody rb = pocisk.GetComponent<Rigidbody>();
            rb.velocity = player.transform.forward * 40;

            Destroy(pocisk, 0.6f);

        }
    }
}
