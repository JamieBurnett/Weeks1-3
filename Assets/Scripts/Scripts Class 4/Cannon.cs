using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonball;
    public float reloadTime;
    public float knockback;

    private float cooldown;

    private Vector3 startPos;
    private Vector3 endPos;

    private float timePass;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosWorld.z = 0;
        if (Input.GetMouseButtonDown(0) && cooldown <=0)
        {
            Instantiate(cannonball,transform.position,Quaternion.identity);
            cooldown = reloadTime;
            endPos = transform.position;
            transform.right = mousePosWorld - transform.position;
            transform.position += Vector3.Normalize(transform.position - mousePosWorld) *knockback;
            startPos = transform.position;
            timePass = 0;
        }
        if(cooldown > 0)
        {
            timePass += Time.deltaTime / reloadTime;
            transform.position = Vector3.Lerp(startPos, endPos, timePass);
            cooldown -= Time.deltaTime;
        }
    }
}
