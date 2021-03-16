using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private Rigidbody enemy;
    private GameObject target;
    
    public GameObject target1;
    public GameObject target2;

    
    public float visibleDistance;
    public float minDistance;
    
    public float moverotation = 10.0f;
    public float movespeed = 10.0f;
    

    void Start()
    {
        enemy = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        if (Vector3.Distance(target1.transform.position, transform.position) < visibleDistance)
        {
            target = target1;

        } else if (Vector3.Distance(target2.transform.position, transform.position) < visibleDistance)
        {
            target = target2;
        }

        if (Vector3.Distance(target.transform.position, transform.position) < visibleDistance)
        {
            Vector3 towards = Vector3.RotateTowards(transform.forward, target.transform.position - transform.position, visibleDistance, 0.0f); 
            towards.y = 0;
            
                    if(transform.rotation == Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(towards), Time.deltaTime * moverotation * 10)) 
                    {
                        if (Vector3.Distance(target.transform.position, transform.position) > minDistance)
                        {
                            enemy.AddForce(transform.TransformDirection(new Vector3(0, 0, 0.2f) * Vector3.Distance(target.transform.position, transform.position) * 100 * Time.deltaTime * movespeed));
                        }
                        else
                        {
                            enemy.velocity = Vector3.zero;
                        }
        
                    }
                    else 
                    { 
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(towards), Time.deltaTime * moverotation * 10);
                    }
        }
    }

  
}
