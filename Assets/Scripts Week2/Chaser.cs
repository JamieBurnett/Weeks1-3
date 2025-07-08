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

    //Excercise 2 stuff
    private SpriteRenderer mySprite;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = gameCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        if (Input.GetMouseButton(0))
        {
            transform.position = mouseWorldPos;
            //moveDir = (mouseWorldPos - transform.position) * speed;
        }
    }

    private void FixedUpdate()
    {
        //I don't believe fixedupdate has been brought up at this point
        //but it's better for motion/physics consistency, apologies if this isn't allowed.
        
        //transform.position += moveDir; (I will use this in the next step)
    }
}
