using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_enemy_range : MonoBehaviour
{
    public Rigidbody2D rb;
    private Camera cam;
    public bool canRotateRef = true;

    Vector2 playerPos;

    private void Start()
    {
        cam = GameObject.Find("Main_Camera").GetComponent<Camera>();
    }
    private void Update()
    {
        //canRotate = canRotateRef;
        playerPos = GameObject.Find("player").GetComponent<Transform>().position;
        rb.transform.localPosition = new Vector3(0, -0.1f, 0);

        //rotate(true);
    }

    private void FixedUpdate()
    {

        Vector2 lookDir = playerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;


    }

    public void rotate(bool canRotate)
    {
        if (canRotate)
        {
            Debug.Log("rotatering");
            
        }
    }
}
