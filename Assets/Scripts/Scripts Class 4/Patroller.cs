using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float timeRatio;
    public float timeToPatrol;
    private int flip = 1;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeRatio += flip*Time.deltaTime/timeToPatrol;
        transform.position = Vector3.Lerp(startPos,endPos,timeRatio);
        if(timeRatio >= 1 || timeRatio <= 0)
        {
            flip = -flip;
        }
    }
}
