using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Transform myTransform;
    [SerializeField] private float mainSpeed;
    
    private Vector3 change;

    public bool player_canget_hit = false;


    private SpriteRenderer spriteRenderer;

    public float dashDistance = 5f;
    public float dashTime = 0.5f;
    private bool isDashing = false;
    public GameObject trail;
    [SerializeField]float elapsedTime = 0.25f;

    public float pushForce = 10f;
    public float pushRadius = 5f;
    public float pushDuration = 2f;
    public LayerMask enemyLayer;

    public ParticleSystem wave;


    void Awake()
    {
        myTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            
            Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

            
            if (inputDirection != Vector2.zero)
            {
                StartCoroutine(Dash(inputDirection));
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            EMP();
            wave.Play();
        }

    }

    void FixedUpdate()
    {
        
        if (change != Vector3.zero)
        {
            Move();
        }

    }



    void Move()
    {
        float new_speed = 10.5f;
        if (change.x != 0 && change.y != 0)
        {
            myTransform.Translate(change.x * new_speed * Time.deltaTime, change.y * new_speed * Time.deltaTime, 0);
        }
        else
        {
            myTransform.Translate(change.x * mainSpeed * Time.deltaTime, change.y * mainSpeed * Time.deltaTime, 0);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy_attack")
        {
            player_canget_hit=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "enemy_attack")
        {
            player_canget_hit = false;
        }
    }


    IEnumerator Dash(Vector2 direction)
    {
        isDashing = true;
        trail.gameObject.SetActive(true);

        Vector3 startPos = transform.position;

       
        Vector3 endPos = startPos + new Vector3(direction.x, direction.y, 0f) * dashDistance;

        
        while (elapsedTime < dashTime)
        {
            
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / dashTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        elapsedTime = 0.25f;
        transform.position = endPos;
        trail.gameObject.SetActive(false);
        
        isDashing = false;
    }


    void EMP()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pushRadius, enemyLayer);

       
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D enemyRigidbody = collider.GetComponent<Rigidbody2D>();

            if (enemyRigidbody != null)
            {
               
                Vector2 pushDirection = (collider.transform.position - transform.position).normalized;

                
                enemyRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

                
                StartCoroutine(StopForceAfterDuration(enemyRigidbody, pushDuration));
            }
        }
    }
    IEnumerator StopForceAfterDuration(Rigidbody2D enemyRigidbody, float duration)
    {
        yield return new WaitForSeconds(duration);

        
        enemyRigidbody.velocity = Vector2.zero;
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pushRadius);
    }

}
