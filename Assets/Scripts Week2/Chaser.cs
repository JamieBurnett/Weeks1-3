using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
