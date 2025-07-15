using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Color myCol;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3 (1,1,1)*Random.Range(0.1f, 5f);
        myCol = Random.ColorHSV();
        GetComponent<SpriteRenderer>().color = myCol;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        if (Vector3.Distance(mouseWorldPos, transform.position) < transform.localScale.x*0.5)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = myCol;
        }
    }
}
