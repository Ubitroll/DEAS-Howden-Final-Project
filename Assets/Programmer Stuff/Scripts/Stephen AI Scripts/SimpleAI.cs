using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAI : MonoBehaviour
{
    //Variables
    public GameObject desk;
    public GameObject machine;

    // AI States
    protected enum state
    {
        Working,
        Fixing
    }

    // Time it takes to fix a machine
    private const float angerTime = 5f;
    private const float fixTime = 15f;

    // Time untill moveing
    private float timeLeftUntilFix = angerTime;
    private float timeLeftUntilWork = fixTime;

    // Denotes the current state
    private state currentState;

    // Navmesh agent
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        // Set state to working
        currentState = state.Working;

        // Set the AI's destination to their desk
        agent.SetDestination(desk.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // If the current state of the AI is working
        if (currentState == state.Working)
        {
            // Determine the distance to the desk
            float distanceToDesk = (desk.transform.position - this.transform.position).magnitude;
            //If the desk is within a certain distance 
            if (distanceToDesk <= 4)
            {

                if (machine.GetComponent<Machine>().currentState == Machine.MachineState.BROKEN)
                {

                    timeLeftUntilFix -= Time.deltaTime;


                    if (timeLeftUntilFix <= 0.0f)
                    {

                        timeLeftUntilFix = angerTime;
                    }

                    if (timeLeftUntilFix == angerTime)
                    {

                        agent.SetDestination(machine.transform.position);
                        agent.stoppingDistance = 3f;
                        currentState = state.Fixing;
                    }
                }
            }
        }

        if (currentState == state.Fixing)
        {

            float distanceToMachine = (machine.transform.position - this.transform.position).magnitude;

            if (distanceToMachine <= 4)
            {

                timeLeftUntilWork -= Time.deltaTime;

                if (timeLeftUntilWork <= 0.0f)
                {

                    timeLeftUntilWork = fixTime;
                }

                if (timeLeftUntilWork == fixTime)
                {

                    machine.GetComponent<Machine>().currentState = Machine.MachineState.WORKING;
                    machine.GetComponent<Machine>().timer.timeLeft = Random.Range(8, 16);
                    agent.SetDestination(desk.transform.position);
                    currentState = state.Working;
                }
            }
        }
        

    }
}
