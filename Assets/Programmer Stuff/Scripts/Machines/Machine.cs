using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{
    public enum MachineState { BROKEN, BREAKING, WORKING }
    public MachineState currentState;
    public Timer timer;
    public float lifeTime;
    [SerializeField] Scrollbar health;
    [SerializeField] Text machineText;


    void Start()
    {
        currentState = MachineState.WORKING;
        GenerateLifeTime();
        timer = new Timer(lifeTime);

    }
    void Update()
    {


        switch (currentState)
        {
            case MachineState.WORKING:

               // transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindWithTag("Player").GetComponent<Player>().machineState = 1;
                machineText.text = "Working...";

                break;

            case MachineState.BROKEN:
               // transform.GetChild(0).gameObject.SetActive(true);
                GameObject.FindWithTag("Player").GetComponent<Player>().machineState = 3;
                machineText.text = "BROKEN";
                break;

            case MachineState.BREAKING:
                GameObject.FindWithTag("Player").GetComponent<Player>().machineState = 2;
                break;

        }


        health.size = (timer.timeLeft * lifeTime) / 100;
        //currentState = CheckStatus();
        timer.Update();
        // Debug.Log(timer.TimeLeft());
        if (timer.timeLeft < 0)
        {
            currentState = MachineState.BROKEN;
        }

    }

    void GenerateLifeTime()
    {
        lifeTime = Random.Range(10, 23);
    }

    MachineState CheckStatus()
    {
        if (!timer.IsActive())
        {
            return MachineState.BROKEN;
        }
        else
        {
            return currentState;
        }
    }
   
}
