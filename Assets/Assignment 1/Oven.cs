using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public GameObject fireTint;

    public Color targetColor;
    public Color batterColor;

    public float ovenWidth;

    public Conveyor conveyorRef;

    // Start is called before the first frame updates
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool ovenOn = false;
        foreach (GameObject i in conveyorRef.Chickens)
        {
            if (Vector3.Distance(i.transform.position, new Vector3(transform.position.x, i.transform.position.y, transform.position.z)) < ovenWidth / 2)
            {
                ovenOn = true;
                i.GetComponent<ChickenTracker>().ovenTime += Time.deltaTime;
                i.GetComponent<SpriteRenderer>().color = Color.Lerp(batterColor, targetColor, i.GetComponent<ChickenTracker>().ovenTime);
            }
        }
        fireTint.SetActive(ovenOn);
    }
}
