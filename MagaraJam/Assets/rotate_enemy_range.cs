using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_enemy_range : MonoBehaviour
{
    public Rigidbody2D rb;
    private Camera cam;

    Vector2 playerPos;

    private void Start()
    {
        cam = GameObject.Find("Main_Camera").GetComponent<Camera>();
    }
    private void Update()
    {
        playerPos = GameObject.Find("player").GetComponent<Transform>().position;
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = playerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
