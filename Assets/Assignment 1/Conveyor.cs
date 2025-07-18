    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public List<GameObject> Chickens; //collection of chicken on the conveyor

    public float speed; //speed the conveyor moves chicken at
    public float chickenSpawnHeight; //height at which chickens spawn

    public GameObject chicken; //prefab to be spawned
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) //spawns chicken every time the spacebar is pressed. The chicken will use the reference to this script we give it to add itself to the chicken list after it finishes falling, allowing it to be moved along.
        {
            GameObject newChicken = Instantiate(chicken, new Vector3(transform.position.x, transform.position.y + chickenSpawnHeight, transform.position.z), Quaternion.identity);
            newChicken.GetComponent<ChickenTracker>().conveyorRef = this;
            newChicken.GetComponent<ChickenTracker>().fallDistance = chickenSpawnHeight - 0.3f;
        }

        if (Input.GetKey(KeyCode.RightArrow)) //moves chicken on the conveyor left or right based on input
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
    }
}
