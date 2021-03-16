using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    
    public void OnCollisionEnter(Collision hit)
    {
        if (hit.transform.tag == "Bullet")
        {
            ruch.health = ruch.health - ruch.damage;
            if (ruch.health <= 0)
            {
                Destroy(hit.gameObject);
            }
            
            gameObject.SetActive(false);
        }
    }
}
