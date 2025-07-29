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
            if (Vector3.Distance(i.transform.position, new Vector3 (transform.position.x,i.transform.position.y,transform.position.z)) < transform.localScale.x / 2) // we check if its in range of the batter
            {
                i.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color; //if so, we change it to be batter coloured
            }
        }
    }
}
