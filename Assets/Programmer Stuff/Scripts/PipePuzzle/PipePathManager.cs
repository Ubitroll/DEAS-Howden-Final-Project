using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePathManager : MonoBehaviour
{
    // Variables
    public Camera cam; // Set to the camera that overlooks the puzzle

    public PipePuzzleState currentState;

    private GameObject[] pipes;
    private GameObject endPipe;
    public GameObject machine;

    // Holds the different states of play
    public enum PipePuzzleState
    {
        Playing,
        NotPlaying,
        Initialising,
        Win
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set state to not playing
        currentState = PipePuzzleState.NotPlaying;

        // Add all game obejects with the tag Pipe to the array Pipes
        pipes = GameObject.FindGameObjectsWithTag("Pipe");

        // Finds the end pipe
        endPipe = GameObject.FindGameObjectWithTag("End_Pipe");
    }

    // Update is called once per frame
    void Update()
    {
        // If in initialising state
        if (currentState == PipePuzzleState.Initialising)
        {
            // For each pipe in the array run the ininialise pipe method from the PipePieceScript
            for (int i = 0; i < pipes.Length; i++)
            {
                pipes[i].GetComponent<PipePieceScript>().InitialisePipe();
            }

            // Set state to playing
            currentState = PipePuzzleState.Playing;
        }

        // If in the playing state
        if (currentState == PipePuzzleState.Playing)
        {
            // If left mouse clicked
            if (Input.GetMouseButtonDown(0))
            {
                // Generate a raycast from the camera to where the mouse clicks
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                // If the raycast hits something
                if (Physics.Raycast(ray, out hit))
                {
                    // If what is hit has the tag 'Pipe'
                    if (hit.collider.tag == "Pipe")
                    {
                        // Rotate 90 degrees around the x
                        hit.transform.Rotate(90, 0, 0);

                        // Increases the current rotation number of the hit pipe
                        hit.collider.GetComponent<PipePieceScript>().currentRotation = hit.collider.GetComponent<PipePieceScript>().currentRotation + 1;

                        // Constrains the current rotation number of the hit pipe between 1 and 4
                        if (hit.collider.GetComponent<PipePieceScript>().currentRotation > 4)
                        {
                            hit.collider.GetComponent<PipePieceScript>().currentRotation = 1;
                        }
                    }
                }
            }

            // If the end pipe is activated
            if (endPipe.GetComponent<PipePieceScript>().isActive == true)
            {
                // Set current state to Win state
                currentState = PipePuzzleState.Win;
            }
        }

        // If state is in the win state
        if (currentState == PipePuzzleState.Win)
        {
            // Fix machine 
            machine.GetComponent<Machine>().currentState = Machine.MachineState.WORKING;
            // Set state to not playing    
            currentState = PipePuzzleState.NotPlaying;

        }
    }
}
