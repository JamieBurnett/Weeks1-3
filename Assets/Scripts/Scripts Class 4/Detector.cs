using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public float colourChangeDistance;

    private SpriteRenderer detectorRenderer;
    private Color startCol;
    private bool colorFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        detectorRenderer = gameObject.GetComponent<SpriteRenderer>();
        startCol = detectorRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosWorld.z = 0;
        float currentDist = Vector3.Distance(mousePosWorld, transform.position);
        if (currentDist <= colourChangeDistance && !colorFlipped)
        {
            colorFlipped = true;
            
            while(detectorRenderer.color == startCol)
            {
                detectorRenderer.color = Random.ColorHSV();
            }
        }
        if (currentDist > colourChangeDistance && colorFlipped)
        {
            colorFlipped = false;
            detectorRenderer.color = startCol;
        }
    }
}
