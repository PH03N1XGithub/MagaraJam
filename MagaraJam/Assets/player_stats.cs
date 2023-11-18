using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_stats : MonoBehaviour
{
    public float player_health = 100f;
    [SerializeField] float batteryTimer = 10;

    private void Update()
    {
        batteryTimer += Time.deltaTime;
        if (batteryTimer > 20)
        {
            batteryTimer = 20;
        }
        if(player_health >= 100f)
        {
            player_health = 100;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            heal();
        }
    }

    void heal()
    {
        if (batteryTimer >= 20) 
        {
            player_health += 20;
            batteryTimer = 0;
        }
    }

}
