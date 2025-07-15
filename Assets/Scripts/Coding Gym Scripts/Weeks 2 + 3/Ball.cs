using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private Vector2 direction = new Vector2(1, 1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this is so ugly but I wanted to account for size
        transform.position += Vector3.right * speed * direction.x * Time.deltaTime;
        if (Camera.main.WorldToScreenPoint(transform.position + new Vector3(transform.localScale.x/2, 0, 0)).x > Screen.width)
        {
            direction.x = -1;
        }
        else if (Camera.main.WorldToScreenPoint(transform.position + new Vector3(-transform.localScale.x / 2,0, 0)).x < 0)
        {
            direction.x = 1;
        }
        transform.position += Vector3.up * speed * direction.y * Time.deltaTime;
        if (Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, transform.localScale.y / 2, 0)).y > Screen.height)
        {
            direction.y = -1;
        }
        else if (Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -transform.localScale.y / 2, 0)).y < 0)
        {
            direction.y = 1;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localScale += new Vector3(1,1,1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale -= new Vector3(1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed += speed; //didnt say how much it had to increase. Lets make it weird.
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = speed*0.5f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
