using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : MonoBehaviour
{
    public Camera gameCamera;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosWorld = gameCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosWorld.z = 0;
        transform.up = mousePosWorld - transform.position;
    }
}
