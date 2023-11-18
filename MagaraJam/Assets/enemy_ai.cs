using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ai : MonoBehaviour
{
    public float enemy_speed = 10f;
    public Transform playerPos;
    public GameObject enemy_range;

    public float enemy_health;
    bool enemy_range_open = false;

    private float enemy_attacking_cooldown = 3f;
    private float enemy_lastAttacked = -9999f;

    bool canMove = true;





    private void Start()
    {
        playerPos = GameObject.Find("player").GetComponent<Transform>();
        enemy_health = 100f;
    }
    private void Update()
    {
        if (canMove) 
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

    IEnumerator Attack()
    {
        canMove = false;
        Vector3 lastPos = new Vector3(
                 enemy_range.transform.eulerAngles.x,
                 enemy_range.transform.eulerAngles.y + 180,
                 enemy_range.transform.eulerAngles.z
            );


        //enemy_range.gameObject.transform.rotation.eulerAngles = lastPos;
        yield return new WaitForSeconds(2);

        if (GameObject.Find("player").GetComponent<Player_Movement>().player_canget_hit && Time.time > enemy_lastAttacked + enemy_attacking_cooldown)
        {

            GameObject.Find("player").GetComponent<player_stats>().player_health -= 20f;

            enemy_lastAttacked = Time.time;
        }
        Debug.Log("enume");

    }



    void EnemyAttack()
    {
         if (enemy_range_open)
        {
            enemy_range.SetActive(true);
               StartCoroutine(Attack());
                Debug.Log("ififififi");

           

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
            //enemy_speed = 0f;
            canMove = false;
            //enemy_range.SetActive(true);
            enemy_range_open=true;
            Debug.Log("range açýk");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "player_range")
        {
            //enemy_speed = 10f;
            canMove = true;
            StartCoroutine(timer());
            
        }
    }


   IEnumerator timer()
    {
        Debug.Log("timer estar");
        yield return new WaitForSeconds(2);
        Debug.Log("timer end");
            enemy_range.SetActive(false);
        enemy_range_open = false;
        canMove = true;
    }
}
