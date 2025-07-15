using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public List<GameObject> Chickens;
    public float speed;
    public GameObject chicken;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            foreach(GameObject i in Chickens)
            {
                i.transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            foreach (GameObject i in Chickens)
            {
                i.transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        if(timer > 3)
        {
            timer = 0;
            Chickens.Add(Instantiate(chicken,new Vector3 (transform.position.x,transform.position.y +0.3f,transform.position.z),Quaternion.identity));
        }
    }
}
