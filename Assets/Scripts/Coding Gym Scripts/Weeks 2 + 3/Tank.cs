using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float speed;
    public GameObject bulletFab;
    public GameObject barrelPivot;
    public Transform barrelEnd;
    public Transform target;
    public GameObject explosion;
    public List<GameObject> liveBullets = new List<GameObject> ();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(1, 0, 0)  * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }

        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosWorld.z = 0;
        barrelPivot.transform.right = mousePosWorld - transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet;
            bullet = Instantiate(bulletFab,barrelEnd.position,Quaternion.identity);
            bullet.transform.right = barrelPivot.transform.right;
            bullet.GetComponent<Bullet>().tank = this;
            Destroy(bullet,5);
            liveBullets.Add(bullet);
        }

        foreach (GameObject i in liveBullets)
        {
            if (Vector3.Distance(i.transform.position, target.position) < target.transform.localScale.x-0.5)
            {
                Destroy(Instantiate(explosion,i.transform.position,Quaternion.identity), 0.5f);
                liveBullets.Remove(i);
                Destroy(i);
            }
        }
        
    }
}
