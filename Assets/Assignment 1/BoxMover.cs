using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMover : MonoBehaviour
{
    public bool move = false; //used to tell the box to start moving offscreen to the right

    public float fallDistance; //how far to fall
    public float fallSpeed; //how fast to fall

    private float fallenDistance; //how far the box has fallen so far

    private bool falling; //used to make the box fall into frame on spawn

    private float moveDelayTimer; //used to offset the box slightly before it moves, to ensure the chicken gets into it
    private float moveDelay = 0.5f; //the time of the delay (private so that it can be universally set, but not different per box)
    // Start is called before the first frame update
    void Start()
    {
        falling = true; //on spawn, fall.
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            transform.position += Vector3.down * fallDistance * fallSpeed * Time.deltaTime; //move the box down
            fallenDistance += fallDistance * fallSpeed * Time.deltaTime; // track how far the box has fallen
            if (fallDistance < fallenDistance)//track if the box has fallen as far as it should, stop falling if so
            {
                falling = false;
            }
        }
        if (move) //check if the box needs to be moving
        {
            if (moveDelayTimer < moveDelay)
            {
                moveDelayTimer += Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime; //move offscreen right
            }           
        }
    }
}
