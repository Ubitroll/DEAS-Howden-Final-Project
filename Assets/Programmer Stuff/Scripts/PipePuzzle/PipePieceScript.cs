using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipePieceScript : MonoBehaviour
{
    // Variables
    public int currentRotation = 1; // Indicates the current rotation
    public int correctRotationOne; // Because pipes can be in the correct position under 2 orientations two variabbles are needed
    public int correctRotationTwo;
    private int numberOfRotations; // Used in the generation of rotations

    public GameObject pipeBehindInSequence; // Indicates which pipe will be supplying the current pipe with water
    public GameObject middleOfPipe; // Lets the script change the colour on the pipe to indicate water flow
    public GameObject pipeManagerObject;

    public bool isInCorrectPosition; // Determines if pipe is in correct postion
    public bool isActive; // Determines if pipe is recieving water from the previous pipe
    public bool isStraight; // Used to distinguish between a straight pipe and a corner pipe

    // Start is called before the first frame update
    void Start()
    {
        InitialisePipe();
    
    }

    // Update is called once per frame
    void Update()
    {
        // If it isnt the start pipe
        if (this.tag != "Start_Pipe")
        {
            // If the previous pipe is in the correct position
            if (pipeBehindInSequence.GetComponent<PipePieceScript>().isInCorrectPosition == true)
            {
                // If the previous pipe is also active with water
                if (pipeBehindInSequence.GetComponent<PipePieceScript>().isActive == true)
                {
                    // If its a straight pipe
                    if (isStraight == true)
                    {
                        // If the pipe is in its first correct orientation
                        if (currentRotation == correctRotationOne)
                        {
                            // Set water to active and that its in the correct position
                            isActive = true;
                            isInCorrectPosition = true;
                        }
                        // If the pipe is in its second correct orientation
                        else if (currentRotation == correctRotationTwo)
                        {
                            // Set water to active and that its in the correct position
                            isActive = true;
                            isInCorrectPosition = true;
                        }
                        // If the pipe isnt in the correct position
                        else
                        {
                            // Set water to inactive and that it isn't the correct position
                            isActive = false;
                            isInCorrectPosition = false;
                        }
                    }
                    // Else if its a corner pipe
                    else if (isStraight == false)
                    {
                        // If the corner pipe is in the position where it can activate but wouldnt be correct for the next piece
                        if (currentRotation == correctRotationOne)
                        {
                            // Set water to active but correct position to false
                            isActive = true;
                            isInCorrectPosition = false;
                        }
                        // If the pipe is in its correct orientation to pass water to the next pipe
                        else if (currentRotation == correctRotationTwo)
                        {
                            // Set water to active and that its in the correct position
                            isActive = true;
                            isInCorrectPosition = true;
                        }
                        // If the pipe isnt in the correct position
                        else
                        {
                            // Set water to inactive and that it isn't the correct position
                            isActive = false;
                            isInCorrectPosition = false;
                        }
                    }
                }
                // Else the pipe should be inactive
                else
                {
                    isActive = false;
                }
            }
            // Else the pipe should be inactive
            else
            {
                isActive = false;
            }
        }

        // Update the colour of any pipes that are active
        UpdateColour();
    }

    // Initialises the pipe
    public void InitialisePipe()
    {
        // If this isnt the starting pipe
        if (this.tag != "Start_Pipe")
        {
            // If this isnt the end pipe
            if (this.tag != "End_Pipe")
            {
                // Generate a random number
                GenerateRandomNumber();

                // Check the pipes rotation
                CheckRotation();

                // While i is less than the number of rotations
                int i = 1;
                while (i < numberOfRotations)
                {
                    // Rotate the piece 90 degreese around the X
                    this.transform.Rotate(90, 0, 0);
                    // Increase the current rotation number and I
                    currentRotation++;
                    i++;

                    // Constrains the current rotation number between 1 and 4
                    if (currentRotation > 4)
                    {
                        currentRotation = 1;
                    }
                }
            }
        }

        // Initialises the start pipe by activating it and setting it in the correct rotation
        if (this.tag == "Start_Pipe")
        {
            isActive = true;
            isInCorrectPosition = true;
        }

        // Update the colour of any pipes that are active
        UpdateColour();
    }

    // Generates a random number for the rotation
    void GenerateRandomNumber()
    {
        numberOfRotations = Random.Range(1, 5);
    }

    // Updates the colour relative to the pipe being active or inactive
    void UpdateColour()
    {
        // If the pipe is in the active state
        if (isActive == true)
        {
            // Set mid sections colour to blue
            middleOfPipe.GetComponent<Renderer>().material.color = Color.blue;
        }

        // If the pipe is in the inactive state
        if (isActive == false)
        {
            // Set mid sections colour to grey
            middleOfPipe.GetComponent<Renderer>().material.color = Color.grey;
        }
    }

    // Checks the rotation
    void CheckRotation()
    {
        // Determines the current rotation of the piece by the orientation of the piece
        if (this.transform.rotation.x == 0)
        {
            currentRotation = 1;
        }

        if (this.transform.rotation.x == 90)
        {
            currentRotation = 2;
        }

        if (this.transform.rotation.x == -270)
        {
            currentRotation = 2;
        }

        if (this.transform.rotation.x == 180)
        {
            currentRotation = 3;
        }

        if (this.transform.rotation.x == -180)
        {
            currentRotation = 3;
        }

        if (this.transform.rotation.x == 270)
        {
            currentRotation = 4;
        }

        if (this.transform.rotation.x == -90)
        {
            currentRotation = 4;
        }
    }
}
