using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosSpawner : MonoBehaviour
{
    public GameObject spawnee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(spawnee,mouseWorldPos,Quaternion.identity);
        }
    }
}
