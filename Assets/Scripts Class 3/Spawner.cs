using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnee;
    public Vector3 spawnPoint;
    public int framerate;
    //public float frequency;
    //public float lifespan;
    public float objectLimit;
    public float destroyIncrement;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = framerate;
        //GameObject spawned = Instantiate(spawnee,spawnPoint,Quaternion.identity);
        //spawned.GetComponent<Pacer>().speed = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        //timer += Time.deltaTime;
        //if (timer >= frequency)   I made the timespawner early, oops
        //{ 
        //    timer = 0;
        //    spawnedObjects.Add(Instantiate(spawnee));
        //    Destroy(spawnedObjects[spawnedObjects.Count-1], lifespan);
        //}
        if (Input.GetMouseButtonDown(0) && spawnedObjects.Count < objectLimit)
        {
            spawnedObjects.Add(Instantiate(spawnee, mouseWorldPos,Quaternion.identity));
            //Destroy(spawnedObjects[spawnedObjects.Count - 1], lifespan);
        }
        if (Input.GetMouseButtonDown(1))
        {
            float delay = destroyIncrement;
            foreach (GameObject i in spawnedObjects) 
            {
                Destroy(i, delay);
                delay += destroyIncrement;
            }
            //for (int i = 0; i <spawnedObjects.Count;i++) the way the prof did it
            //{
            //    Destroy(spawnedObjects[i], delay);
            //    delay += destroyIncrement;
            //}
            spawnedObjects.Clear();
        }
    }
}
