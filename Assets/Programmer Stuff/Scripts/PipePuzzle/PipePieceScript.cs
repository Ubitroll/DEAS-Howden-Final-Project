using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipePieceScript : MonoBehaviour
{
    // Variables
    public int currentRotation = 1;
    public int correctRotationOne;
    public int correctRotationTwo;
    private int numberOfRotations;

    public GameObject pipeBehindInSequence;
    public GameObject middleOfPipe;

    public bool isInCorrectPosition; // Determines if pipe is in correct postion
    public bool isActive; // Determines if pipe is recieving water
    public bool isStraight;

    // Start is called before the first frame update
    void Start()
    {
        if (this.tag != "Start_Pipe")
        {
            if (this.tag != "End_Pipe")
            {
                GenerateRandomNumber();

                CheckRotation();

                int i = 1;
                while (i < numberOfRotations)
                {
                    this.transform.Rotate(90, 0, 0);
                    currentRotation++;
                    i++;

                    if (currentRotation > 4)
                    {
                        currentRotation = 1;
                    }

                }
            }
        }

        if (this.tag == "Start_Pipe")
        {
            isActive = true;
            isInCorrectPosition = true;
        }

        UpdateColour();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag != "Start_Pipe")
        {


            if (pipeBehindInSequence.GetComponent<PipePieceScript>().isInCorrectPosition == true)
            {
                if (pipeBehindInSequence.GetComponent<PipePieceScript>().isActive == true)
                {
                    if (isStraight == true)
                    {

                        if (currentRotation == correctRotationOne)
                        {
                            isActive = true;
                            isInCorrectPosition = true;
                        }
                        else if (currentRotation == correctRotationTwo)
                        {
                            isActive = true;
                            isInCorrectPosition = true;
                        }
                        else
                        {
                            isActive = false;
                            isInCorrectPosition = false;
                        }
                    }
                    else if (isStraight == false)
                    {

                        if (currentRotation == correctRotationOne)
                        {
                            isActive = true;
                        }
                        else if (currentRotation == correctRotationTwo)
                        {
                            isActive = true;
                            isInCorrectPosition = true;
                        }
                        else
                        {
                            isActive = false;
                            isInCorrectPosition = false;
                        }

                    }
                }
                else
                {
                    isActive = false;
                }
            }
            else
            {
                isActive = false;

            }
        }

        UpdateColour();
    }

    void GenerateRandomNumber()
    {
        numberOfRotations = Random.Range(1, 5);
    }

    void UpdateColour()
    {
        if (isActive == true)
        {
            middleOfPipe.GetComponent<Renderer>().material.color = Color.blue;
        }

        if (isActive == false)
        {
            middleOfPipe.GetComponent<Renderer>().material.color = Color.grey;
        }
    }

    void CheckRotation()
    {
        // Convers the current rotation
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
