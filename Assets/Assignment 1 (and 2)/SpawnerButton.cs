using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerButton : MonoBehaviour
{
    public Conveyor conveyorRef; //used for granting the conveyor access to the chicken and vice versa, as well as for the chicken spawning variables
    
    private Vector3 chickenSpawnLocation; //the location to spawn new chickens at

    private void Start()
    {
        //sets chicken spawn location based on the conveyor location, done in start as conveyor doesnt move during run time
        chickenSpawnLocation = new Vector3(conveyorRef.transform.position.x, conveyorRef.transform.position.y + conveyorRef.chickenSpawnHeight, conveyorRef.transform.position.z); 
    }


    /// <summary>
    /// creates a new chicken object and adds it to the conveyor's array of chickens being tracked
    /// </summary>
    public void SpawnChicken()
    {       
        GameObject newChicken = Instantiate(conveyorRef.chicken, chickenSpawnLocation, Quaternion.identity);
        newChicken.GetComponent<ChickenTracker>().conveyorRef = conveyorRef;
        newChicken.GetComponent<ChickenTracker>().fallDistance = conveyorRef.chickenSpawnHeight - 0.3f;
    }
}
