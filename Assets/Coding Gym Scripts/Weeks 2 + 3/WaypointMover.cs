using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    public List<Transform> Waypoints;
    public float speed;
    public GameObject waypointPrefab;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Waypoints[index].position)<0.5)
        {
            if (index +1 >= Waypoints.Count)
            {
                index = 0;
            }
            else
            {
                index += 1;
            }
        }
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
       
        if (Input.GetMouseButtonDown(0))
        {
            Waypoints.Add(Instantiate(waypointPrefab, mouseWorldPos, Quaternion.identity).transform);
        }
        if (Input.GetMouseButtonDown(1) && Waypoints.Count > 1)
        {
            GameObject closest = Waypoints[0].gameObject; //this is uneccessary, but unity didnt think so
            float distance = 100;
            foreach(Transform i in Waypoints)
            {
                if (Vector3.Distance(mouseWorldPos, i.position) < distance)
                {
                    closest = i.gameObject;
                    distance = Vector3.Distance(i.position, mouseWorldPos);
                }
            }
            if(index >= Waypoints.Count-1)
            {
                index = 0;
            }
            Waypoints.Remove(closest.transform);
            Destroy(closest);
        }
        Vector3 direction = Waypoints[index].position - transform.position;
        transform.position += direction * speed * Time.deltaTime;
    }
}
