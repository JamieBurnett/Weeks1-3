using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;
    public float baseSpeed;
    public Tank tank;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        velocity = transform.right * baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        velocity += acceleration*Time.deltaTime;
        transform.position += velocity * Time.deltaTime;    
    }

    private void OnDestroy()
    {
        tank.liveBullets.Remove(gameObject);
    }
}
