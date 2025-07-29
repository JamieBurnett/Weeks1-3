using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public GameObject fireTint; //the red transparent tint which goes over the oven while it's on

    public Color targetColor; //the toasted colour
    public Color batterColor; //the colour of battered chickens
    public Color burntColor; //the colour of burnt chickens

    public float ovenWidth; //used to alter the size the oven checks for chicken at
    public float cookTime; //time chicken can cook before burning

    public Conveyor conveyorRef; //reference to the conveyor to access the chickens

    public float heat; //the rate at which the chicken cooks
    // Update is called once per frame
    void Update()
    {
        bool ovenOn = heat >0; //check whether the oven is currently turned on
        foreach (GameObject i in conveyorRef.Chickens)
        {
            if (Vector3.Distance(i.transform.position, new Vector3(transform.position.x, i.transform.position.y, transform.position.z)) < ovenWidth / 2) //checks if the  chicken is close enough to be in the oven
            {               
                i.GetComponent<ChickenTracker>().ovenTime += Time.deltaTime*heat;
               
                if(i.GetComponent<ChickenTracker>().ovenTime >= cookTime)
                {
                    i.GetComponent<SpriteRenderer>().color = Color.Lerp(targetColor, burntColor, i.GetComponent<ChickenTracker>().ovenTime -cookTime); //if it is, uses the time the chicken has been in the oven to tint it appropriately
                }
                else
                {
                    i.GetComponent<SpriteRenderer>().color = Color.Lerp(batterColor, targetColor, i.GetComponent<ChickenTracker>().ovenTime); //if it is, uses the time the chicken has been in the oven to tint it appropriately
                }
            }
        }
        fireTint.SetActive(ovenOn); // shows the red tint of the oven if any chicken nuggets are inside it
    }

    //sets the heat to the new given value
    public void SetHeat(float newHeat)
    {
        heat = newHeat;
    }
}
