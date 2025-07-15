using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPos;
    private Vector3 endPos;

    private float timePass;

    public float moveDur;
    void Start()
    {
        startPos = transform.position;
        endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        endPos.z = 0;
        Destroy(gameObject,moveDur);
    }

    // Update is called once per frame
    void Update()
    {
        timePass += Time.deltaTime / moveDur;
        transform.position = Vector3.Lerp(startPos, endPos, timePass);
    }
}
