using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Transform myTransform;
    [SerializeField] private float mainSpeed;

    private Vector3 change;

    



    void Awake()
    {
        myTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        
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
        float new_speed = 4.5f;
        if (change.x != 0 && change.y != 0)
        {
            myTransform.Translate(change.x * new_speed * Time.deltaTime, change.y * new_speed * Time.deltaTime, 0);
        }
        else
        {
            myTransform.Translate(change.x * mainSpeed * Time.deltaTime, change.y * mainSpeed * Time.deltaTime, 0);
        }



    }
}
