using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStation : MonoBehaviour
{
    public GameObject boxFab; //the box prefab

    public Transform boxSpawnPoint; //the point where the box will be spawned.

    public int chickensPerBox; //the number of chickens needed before a box will move offscreen and be replaced.

    public float boxWidth; //used to alter the range the box checks for chicken at

    public Conveyor conveyorRef; //reference to the conveyor to access the chickens

    private int chickensInBox = 0;

    private GameObject currentBox;

    private void Start()
    {
        currentBox = Instantiate(boxFab, boxSpawnPoint.position, Quaternion.identity);//on start, spawn the first box
        currentBox.GetComponent<BoxMover>().fallDistance = boxSpawnPoint.position.y - transform.position.y; //tell it how far to fall
    }
    // Update is called once per frame
    void Update()
    {
        List<GameObject> chickensToRemove = new List<GameObject>(); //a list of chicken nuggets that have reached the boxes, and thus need cleaned up from the conveyor's list of active chicken
        foreach (GameObject i in conveyorRef.Chickens)
        {
            if (Vector3.Distance(i.transform.position, new Vector3(transform.position.x, i.transform.position.y, transform.position.z)) < boxWidth / 2) //checks if the  chicken is close enough to fall, then if so, tells it to fall into the box station
            {
                chickensToRemove.Add(i);
                if (currentBox.GetComponent<BoxMover>().falling)
                {
                    i.GetComponent<ChickenTracker>().fallDistance = i.transform.position.y - transform.position.y+10;
                }
                else
                {
                    i.GetComponent<ChickenTracker>().fallDistance = i.transform.position.y - transform.position.y;
                }
                i.GetComponent<ChickenTracker>().falling = true;
            }
        }
        foreach(GameObject i in chickensToRemove) //remove the chicken we found to be in range to fall into boxes
        {
           chickensInBox++;
           conveyorRef.Chickens.Remove(i);
           Destroy(i, 0.5f); //then remove the game object as the chicken has been "packed" into a box
        }
    }

    //spawns a new box and moves the old box offscreen
    public void SpawnNewBox()
    {
        chickensInBox = 0;
        currentBox.GetComponent<BoxMover>().move = true;
        Destroy(currentBox, 10); //destroy the box at some point after it moves offscreen. When isn't as important as that it gets cleaned up.

        currentBox = Instantiate(boxFab, boxSpawnPoint.position, Quaternion.identity); //make a new box for the next batch of nuggets
        currentBox.GetComponent<BoxMover>().fallDistance = boxSpawnPoint.position.y - transform.position.y;
    }
}
