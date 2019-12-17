using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{

    int machinesWorking;
    bool pointAdded;
    int points;    
    public float pointsTimer = 3;
    int Score;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Machine").GetComponent<Machine>().currentState == Machine.MachineState.WORKING && pointAdded == false)
        {
            machinesWorking++;
            pointAdded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Machine").GetComponent<Machine>().currentState == Machine.MachineState.WORKING && pointAdded == false)
        {
            machinesWorking++;
            pointAdded = true;
        }

        if (GameObject.Find("Machine").GetComponent<Machine>().currentState != Machine.MachineState.WORKING && pointAdded == true)
        {
            machinesWorking--;
            pointAdded = false;
        }


        switch (machinesWorking)
        {
            case 0:

                points = 0;

                break;

            case 1:

                points = 50;

                break;

            case 2:

                points = 100;

                break;

        }

        if(pointsTimer > 0)
        pointsTimer -= Time.deltaTime;

        if (pointsTimer <= 0)
        {
            Score += points;
            pointsTimer = 3;
        }

        GameData.playerScore = Score;
    }
}
