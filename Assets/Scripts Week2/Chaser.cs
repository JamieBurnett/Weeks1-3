using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Vector3 newPosition;
    public Vector3 moveDir;
    public Camera gameCamera;

    //Excercise 1 stuff
    public float speed;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mouseWorldPos = gameCamera.ScreenToWorldPoint(Input.mousePosition);
       // mouseWorldPos.z = 0f;
       // transform.position = mouseWorldPos;
    }

    private void FixedUpdate()
    {
        //I don't believe fixedupdate has been brought up at this point
        //but it's better for motion/physics so...
        Vector3 mouseWorldPos = gameCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        moveDir = (mouseWorldPos - transform.position )*speed;
        transform.position += moveDir;


    }
}
