using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float timeRatio;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeRatio += Time.deltaTime/5;
        transform.position = Vector3.Lerp(startPos,endPos,timeRatio);
        if(timeRatio >= 1)
        {
            Vector3 holder;
            holder = startPos;
            startPos = endPos;
            endPos = holder;
            timeRatio = 0;
        }
    }
}
