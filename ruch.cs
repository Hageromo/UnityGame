using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ruch : MonoBehaviour
{
    public GameObject enemy;
    
    public List<Transform> points = new List<Transform>();
    private Transform targetPoint; 
    
    private int targetPointIndex = 0;
    private float minDistance = 0.1f; 
    private int lastPointIndex;

    public float movementSpeed;
    public float rotationSpeed;

    public float angle;
    private Animator anim;

    public bool line = true;
    
    public static float health = 100;
    public static float damage = 34;
    void Start()
    {
        lastPointIndex = points.Count - 1;
        targetPoint = points[targetPointIndex];
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (line == true)
        {
            Debug.DrawLine(new Vector3(289f, 102.9804f, 220.3306f), new Vector3(289f, 112.9804f, 220.3306f), Color.white);
            Debug.DrawLine(new Vector3(289f, 102.976f, 222.97f), new Vector3(289f, 112.976f, 222.97f), Color.white);
            Debug.DrawLine(new Vector3(290f, 102.7414f, 228.8206f), new Vector3(290f, 112.7414f, 228.8206f), Color.white);
            Debug.DrawLine(new Vector3(296f, 101.8524f, 222.97f), new Vector3(296f, 111.8524f, 222.97f), Color.white);
        }

        Move();
    }

    void Move()
    {

        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetPoint.position - transform.position;
        directionToTarget.y = 0.0f;
        
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);


        if (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(directionToTarget)) > angle)
        {
            anim.SetFloat("Speed", 0.0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);
        }
        else
        {
            anim.SetFloat("Speed", movementSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, movementStep);
            float distance = Vector3.Distance(transform.position, targetPoint.position);
            
            Distance(distance);
        }
        
    }
    
    void Distance(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetPointIndex++;
            
            if (targetPointIndex > lastPointIndex)
            {
                targetPointIndex = 0;
            }

            targetPoint = points[targetPointIndex];
        }
    }

   
}
    



