using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    float minutes;
    int hours;    
  
    // Update is called once per frame
    void Update()
    {
        GameClock();


    }

    public void GameClock()
    {

        minutes += Time.deltaTime;

        if (minutes >= 59)
        {
            hours += 1;
            minutes = 0;
        }      

        GameData.minutes = minutes;
        GameData.hours = hours + 9;
    }

}
