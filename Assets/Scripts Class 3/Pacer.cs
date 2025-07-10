using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Pacer : MonoBehaviour
{
    public float speed;
    private Vector2 direction = new Vector2 (1,1);

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        transform.position += Vector3.right * speed * direction.x*Time.deltaTime;
        if (screenPosition.x > Screen.width)
        {
            direction.x = -1;
        }
        else if (screenPosition.x <0)
        {
            direction.x = 1;
        }
        transform.position += Vector3.up * speed * direction.y * Time.deltaTime;
        if (screenPosition.y > Screen.height)
        {
            direction.y = -1;
        }
        else if (screenPosition.y < 0)
        {
            direction.y = 1;
        }
    }
}
