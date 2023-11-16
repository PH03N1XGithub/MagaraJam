using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player_transform;

    private void Update()
    {
        transform.position = player_transform.position + new Vector3(0,0, -10);
    }
}
