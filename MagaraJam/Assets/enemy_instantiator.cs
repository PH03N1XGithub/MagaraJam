using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_instantiator : MonoBehaviour
{
    public GameObject enemy;
    private GameObject instantiated_enemy;
    private Transform enemyPos;
    private Transform playerPos;
    //public float enemy_speed = 1f;

    public float instantiate_cooldown = 3f;
    private float last_instantatedAt = -9999f;


    

    private void FixedUpdate()
    {
        playerPos = GameObject.Find("player").GetComponent<Transform>();
    }

    private void Update()
    {

        InstantiateEnemy();
        
    }

    

    void InstantiateEnemy()
    {
        if(Time.time > last_instantatedAt + instantiate_cooldown)
        {
            instantiated_enemy = Instantiate(enemy);
            instantiated_enemy.transform.position = new Vector3(Random.Range(-30f, 30f), Random.Range(-30f, 30f), 0);
            last_instantatedAt = Time.time; 
        }
        
    }

    
    
        
       
    

    
}
