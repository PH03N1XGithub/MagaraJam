using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ai : MonoBehaviour
{
    private float enemy_speed = 3f;
    public Transform playerPos;

    public float enemy_health;
    

    private void Start()
    {
        playerPos = GameObject.Find("player").GetComponent<Transform>();
        enemy_health = 100f;
    }
    private void Update()
    {
        EnemyMovement();
        if(enemy_health <= 0)
        {
            Destroy(gameObject);
        }

        
    }


    void EnemyMovement()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, playerPos.position, enemy_speed * Time.deltaTime);
    }

    
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            enemy_health -= 20f;
            Debug.Log("vurulduk -20 can");
        }

        if(collision.tag == "Player")
        {
            enemy_speed = 0f;
            Debug.Log("durduk");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            enemy_speed = 3f;
        }
    }
}
