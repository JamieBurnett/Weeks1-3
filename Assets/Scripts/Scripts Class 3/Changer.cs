using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Changer : MonoBehaviour
{
    public Sprite changeTo;
    public float stepTime;
    private float internalTimer;
    private int step = 0;
    public SpriteRenderer mySprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        internalTimer += Time.deltaTime;
        if (internalTimer > stepTime)
        {
            internalTimer = 0;
            if (step == 0) //I want to use a case here so bad it's so much nicer
            {
                mySprite.color = Color.green;
            }
            else if (step == 1)
            {
                transform.localScale = new Vector3(2, 2, 2);
            }
            else if (step == 2)
            {
                mySprite.sprite = changeTo;
            }
            else if (step == 3)
            {
                Destroy(gameObject);
            }
            step += 1;
        }
    }


}
