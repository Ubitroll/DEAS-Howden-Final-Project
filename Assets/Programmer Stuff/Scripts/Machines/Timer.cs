using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public float timeLeft;
    bool active;

    public Timer(float lifetime)
    {
        timeLeft = lifetime;
    }

    public void StartTimer(float lifetime)
    {
        timeLeft = lifetime;
        active = true;
    }

    public void Update()
    {
        if (timeLeft < 0)
        {
            active = false;
        }
        else
        {
            timeLeft -= Time.deltaTime;

        }
    }

    public bool IsActive(){
        return active;
    }

    public float TimeLeft()
    {
        return timeLeft;
    }
}
