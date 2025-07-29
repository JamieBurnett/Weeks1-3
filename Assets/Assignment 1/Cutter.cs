using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public Conveyor conveyorRef; //reference to the conveyor, and by association all the chicken on it

    public Sprite[] nuggetShapes; //a list of potential shapes to cut nuggets into
    public Sprite uncutChickenSpr; //the default sprite for chicken
    public Sprite poorlyCutChickenSpr; //the sprite for chicken thats been overcut

    public float speed; //speed the cutter drops at

    private bool animating; //used to track whether the cutter is currently mid animation, to prevent overlap or choppy animation

    private float startHeight; //tracks the location the cutter started at so it can return to it after cutting

    private int step; //used to track which animation step we're on and move through them in sequence
    // Start is called before the first frame update
    void Start()
    {
        startHeight = transform.position.y; //tracks the location the cutter started at so it can return to it after cutting
    }

    // Update is called once per frame
    void Update()
    {
        if (!animating) //while not actively animating, we check if chicken is nearby
        {
            foreach (GameObject i in conveyorRef.Chickens)
            {
                if (Vector3.Distance(i.transform.position, new Vector3(transform.position.x,i.transform.position.y,transform.position.z)) < 0.5f) //if it is, start animating at the first step
                {
                    animating = true;
                    step = 0;
                }
            }
        }
        if (animating) //when animating, we check what step we're in and whether we've reached the end
        {
            if (step == 0 && transform.position.y > startHeight - 1)
            {
                transform.position += Vector3.down * Time.deltaTime * speed; //first we move down
                if(transform.position.y <= startHeight - 1)
                {
                    step++;
                }
            } else if (step == 1) 
            {
                foreach (GameObject i in conveyorRef.Chickens)  //then for ALL chickens in range, we change them to one of the nugget shapes from our list, but only if they currently have the default chicken sprite
                {
                    if(Vector3.Distance(i.transform.position,transform.position) < transform.localScale.x / 2 )
                    {
                        if(i.GetComponent<SpriteRenderer>().sprite == uncutChickenSpr)
                        {
                            i.GetComponent<SpriteRenderer>().sprite = nuggetShapes[Random.Range(0, nuggetShapes.Length)];
                        }
                        else
                        {
                            i.GetComponent<SpriteRenderer>().sprite = poorlyCutChickenSpr;
                        }
                        i.GetComponent<ChickenTracker>().cuts += 1;
                    }                    
                }
                step++;
            }else if (step == 2 && transform.position.y < startHeight) //finally, we reset back to normal height, and set animating to false to go back into chicken detection mode
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
