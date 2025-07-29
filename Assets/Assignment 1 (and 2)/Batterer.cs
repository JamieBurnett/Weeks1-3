using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batterer : MonoBehaviour
{
    public Conveyor conveyorRef; //used to gain access to the list of chicken nuggets on the conveyor
    void Update()
    {
        foreach (GameObject i in conveyorRef.Chickens) //iterate through all the active chicken
        {
            ChickenTracker chicken = i.GetComponent<ChickenTracker>();
            if (Vector3.Distance(i.transform.position, new Vector3 (transform.position.x,i.transform.position.y,transform.position.z)) < transform.localScale.x / 2) // we check if its in range of the batter
            {
                if (!chicken.inBatter) //check if it has entered the batter this frame
                {
                    i.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color; //if so, we change it to be batter coloured
                    chicken.inBatter = true; //ensure we done instantly double batter it
                    chicken.batterLayers++; //track how many layers of batter we have added
                    if (i.transform.localScale.y - 0.01f > 0f) //ensure we dont set scale.y to 0
                    {
                        i.transform.localScale = new Vector3(i.transform.localScale.x, i.transform.localScale.y - 0.01f, i.transform.localScale.z); //a very bad way to show adding batter layers (making the sprite get squished slightly). 
                    }
                }
            }
            else //tell the chicken when it leaves the batter
            {
                chicken.inBatter = false;
            }
        }
    }
}
