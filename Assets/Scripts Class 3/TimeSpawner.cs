using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpawner : MonoBehaviour
{
    public GameObject spawnee;
    public float frequency;
    public float lifespan;
    public float destroyIncrement;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        timer += Time.deltaTime;
        if (timer >= frequency)
        {
            timer = 0;
            spawnedObjects.Add(Instantiate(spawnee));
            spawnedObjects[spawnedObjects.Count - 1].GetComponent<SpriteRenderer>().color = Color.red; //wanted to differentiate from the click-spawned ones
            Destroy(spawnedObjects[spawnedObjects.Count - 1], lifespan);
        }
    }
}
