using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_logic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }

}
