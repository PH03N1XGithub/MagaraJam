using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ai : MonoBehaviour
{
    private float enemy_speed = 3f;
    public Transform playerPos;
    public GameObject enemy_range;

    public float enemy_health;
    bool enemy_range_open = false;

    private float enemy_attacking_cooldown = 3f;
    private float enemy_lastAttacked = -9999f;
    
    

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

        EnemyAttack();
    }


    void EnemyMovement()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, playerPos.position, enemy_speed * Time.deltaTime);
    }

    
  
        
    
    void EnemyAttack()
    {
        if (enemy_range_open)
        {
            enemy_range.SetActive(true);

            if (GameObject.Find("player").GetComponent<Player_Movement>().player_canget_hit && Time.time > enemy_lastAttacked + enemy_attacking_cooldown)
            {
                GameObject.Find("player").GetComponent<player_stats>().player_health -= 20f;
                Debug.Log("oyuncu vuruldu -20 can");
                enemy_lastAttacked = Time.time;
            }

        }
    }


    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            enemy_health -= 20f;
            Debug.Log("enemy vuruldu -20 can");
        }

        if(collision.tag == "player_range")
        {
            enemy_speed = 0f;
            //enemy_range.SetActive(true);
            enemy_range_open=true;
            Debug.Log("range açýk");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "player_range")
        {
            enemy_speed = 3f;
            enemy_range.SetActive(false);
            enemy_range_open=false;
        }
    }
}
