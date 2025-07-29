using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityChecker : MonoBehaviour
{
    public Conveyor conveyorRef; //used to gain access to the list of chicken nuggets on the conveyor

    public float cookTimeTarget;
    public float burnTime;
    public float qaZoneWidth;

    public TMPro.TextMeshProUGUI ScoreText;
    void Update()
    {
        foreach (GameObject i in conveyorRef.Chickens) //iterate through all the active chicken
        {
            if (Vector3.Distance(i.transform.position, new Vector3(transform.position.x, i.transform.position.y, transform.position.z)) < qaZoneWidth / 2) // we check if its in range of the quality zone
            {
                int score = 0;
                ChickenTracker nugget = i.GetComponent<ChickenTracker>();
                if(nugget.ovenTime > cookTimeTarget && nugget.ovenTime < burnTime) score++;
                if (nugget.cuts == 1) score++;
                SetScoreText(score);
            }
        }
    }

    private void SetScoreText(int score)
    {
        switch (score)
        {
            case 0:
                ScoreText.color = Color.red;
                ScoreText.text = "BAD!";
                break;
            case 1:
                ScoreText.color = Color.yellow;
                ScoreText.text = "OK!";
                break;
            case 2:
                ScoreText.color = Color.green;
                ScoreText.text = "PERFECT!!";
                break;
        }
             
    }
}
