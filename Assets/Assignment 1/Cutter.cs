using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public Conveyor conveyorRef;
    public Sprite[] nuggetShapes;
    public float speed;
    private bool animating;
    private float startHeight;
    private int step;
    // Start is called before the first frame update
    void Start()
    {
        startHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!animating)
        {
            foreach (GameObject i in conveyorRef.Chickens)
            {
                if (Vector3.Distance(i.transform.position, new Vector3(transform.position.x,i.transform.position.y,transform.position.z)) < 0.5f)
                {
                    animating = true;
                    step = 0;
                }
            }
        }
        if (animating)
        {
            if (step == 0 && transform.position.y > startHeight - 1)
            {
                transform.position += Vector3.down * Time.deltaTime * speed;
                if(transform.position.y <= startHeight - 1)
                {
                    step++;
                }
            } else if (step == 1) 
            {
                foreach (GameObject i in conveyorRef.Chickens)
                {
                    if(Vector3.Distance(i.transform.position,transform.position) < transform.localScale.x / 2)
                    {
                        i.GetComponent<SpriteRenderer>().sprite = nuggetShapes[Random.Range(0, nuggetShapes.Length)];
                    }                    
                }
                step++;
            }else if (step == 2 && transform.position.y < startHeight)
            {
                transform.position += Vector3.up * Time.deltaTime * speed;
                if (transform.position.y >= startHeight)
                {
                    animating = false;
                }
            }

        }
        
    }
}
