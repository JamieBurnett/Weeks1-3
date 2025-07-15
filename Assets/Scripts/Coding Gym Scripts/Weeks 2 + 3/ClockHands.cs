using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHands : MonoBehaviour
{
    public float clockspeed;
    public List<GameObject> clockhands; //this is a little I just don't want 2 seperate variables and im tired
    // Start is called before the first frame update
    public GameObject orbitPivot;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int timeMultiplier = -1;
        foreach (GameObject i in clockhands)
        {
            i.transform.eulerAngles += new Vector3(0, 0, clockspeed * timeMultiplier * Time.deltaTime);
            timeMultiplier = timeMultiplier*12;
        }
        orbitPivot.transform.eulerAngles += new Vector3(0, 0, clockspeed * 0.5f * Time.deltaTime);
    }
}
