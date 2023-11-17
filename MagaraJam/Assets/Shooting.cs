using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bullet_speed = 150f;
    public int bullet_count = 11;
    public int max_bullet_count = 11;

    public float shooting_cooldown = 1f;
    private float lastAttackedAt = -9999f;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && bullet_count > 0)
        {
            if(Time.time > lastAttackedAt + shooting_cooldown) 
            {
               
                Shoot();
                bullet_count--;
                lastAttackedAt = Time.time;
            }
            
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            bullet_count = max_bullet_count;
            lastAttackedAt = Time.time;
        }

        if(bullet_count == 0)
        {
            Console.WriteLine("we run out of bullets");
        }
    }

    

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bullet_speed, ForceMode2D.Impulse);
        
    }
}
