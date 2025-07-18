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
        Vector3 screenPos = gameCamera.WorldToScreenPoint(transform.position);
        bool xExceeded = screenPos.x > Screen.width || screenPos.x < 0;
        bool yExceeded = screenPos.y < 0 || screenPos.y > Screen.height;

        if (Input.GetMouseButton(0))
        {
            moveDir = (mouseWorldPos - transform.position) * speed;
        }
        if (Vector3.Distance(transform.position,mouseWorldPos) < 0.5) //to stop the square from going off into infinity
        {
            moveDir = new Vector3(0,0,0);
        }
        if (Input.GetMouseButton(1))
        {
            moveDir = (transform.position - mouseWorldPos) * speed;
        }
       
        Debug.Log("Position:" + transform.position.x + "Out of bounds x?: " + xExceeded + " Out of bounds y?: " + yExceeded);

        if (xExceeded || yExceeded )
        {
            mySprite.color = Color.red;
        }
        else
        {
            mySprite.color = Color.white;
        }        
    }

    private void FixedUpdate()
    {
        //I don't believe fixedupdate has been brought up at this point
        //but it's better for motion/physics consistency, apologies if this isn't allowed.
        
        transform.position += moveDir;
        
    }
}
