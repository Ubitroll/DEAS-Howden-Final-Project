using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    float minutes;
    int hours;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameClock();


    }

    public void GameClock()
    {
        
        
        if (minutes > 59)
        {
            hours =+ 1;
            minutes = 0;
        }
        else
        {
            minutes += Time.deltaTime;
        }
        GameData.minutes = minutes;
        GameData.hours = hours;
    }

}
