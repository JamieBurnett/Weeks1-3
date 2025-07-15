using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructor : MonoBehaviour
{
    public float startValue;
    public float endValue;
    public float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float output = Mathf.Lerp(startValue,endValue,currentTime);
        Debug.Log(output);
    }
}
