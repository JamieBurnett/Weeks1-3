using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvader : MonoBehaviour
{
    private float timerKeeper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerKeeper += Time.deltaTime;
        if(timerKeeper >= 0.5)
        {
            timerKeeper = 0;
            transform.position -= new Vector3(0, 1, 0);
        }
    }
}
