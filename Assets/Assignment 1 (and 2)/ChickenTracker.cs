using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenTracker : MonoBehaviour
{
    public float ovenTime; //time spent cooking
    public float fallDistance; //how far to fall
    public float fallSpeed; //how fast to fall

    public Conveyor conveyorRef; // a reference to the conveyor

    public bool falling = true; //used when the chicken is being dropped. starts as true as the chicken is spawned in the air.
    public bool inBatter;//used to check when chicken enters and leaves batter
    
    public int cuts; //tracks how many times this chicken has been cut before
    public int batterLayers;//tracks how many layers of batter are on the chicken

    private float fallenDistance; //used to track the distance the chicken has fallen so far
    
    private bool onConveyorList; //a kind of gross way to make this work by adding itself to the list once the falling ends.

    private void Update()
    {
        if (falling)
        {
            transform.position += Vector3.down *fallDistance * fallSpeed * Time.deltaTime; //move the chicken down
            fallenDistance += fallDistance * fallSpeed * Time.deltaTime; // track how far the chicken has fallen
            if (fallDistance < fallenDistance)//track if the chicken has fallen as far as it should, stop falling if so
            { 
                falling = false;
                fallenDistance = 0; //reset for when we next fall
            } 
        }else if (!onConveyorList)
        {
            conveyorRef.Chickens.Add(gameObject); //Once we stop falling, check if we're on the conveyor list. if not, add ourselves. (we could technically make this more robust with checking if the list contains the object directly instead)
            onConveyorList = true;
        }
    }
}

