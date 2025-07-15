using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batterer : MonoBehaviour
{
    public Conveyor conveyorRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject i in conveyorRef.Chickens)
        {
            if (Vector3.Distance(i.transform.position, new Vector3 (transform.position.x,i.transform.position.y,transform.position.z)) < transform.localScale.x / 2)
            {
                i.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            }
        }
    }
}
