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
            if (Vector3.Distance(i.transform.position, new Vector3(transform.position.x, i.transform.position.y, transform.position.z)) < qaZoneWidth / 2) // we check if its in range of the quality zone, then will check the number of cuts and cook time, adding to the score for each aspect correctly done
            {
                int score = 0;
                ChickenTracker nugget = i.GetComponent<ChickenTracker>();
                if(nugget.ovenTime > cookTimeTarget && nugget.ovenTime < burnTime) score++;
                if (nugget.cuts == 1) score++;
                SetScoreText(score);
            }
        }
    }

    /// <summary>
    /// takes in the score of the chicken which is currently being judged.
    /// sets the score text to BAD, OK, or PERFECT, and changes it's color to red, yellow, or green, respectively, based on the score
    /// </summary>
    /// <param name="score"></param>
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
