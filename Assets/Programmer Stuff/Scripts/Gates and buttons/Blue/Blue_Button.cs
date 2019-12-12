using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Button : MonoBehaviour
{
    public bool isButtonPressed = false;

    private float speed = 2;

    public float maxY;
    public float minY;

    void Update()
    {
        //visually moves the button down to indicate its been pressed

        if (isButtonPressed == true)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            if (transform.position.y < minY)
            {
                speed = 0;
            }
            else
            {
                speed = 2;
            }
        }

        if (isButtonPressed == false)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            if (transform.position.y > maxY)
            {
                speed = 0;
            }
            else
            {
                speed = 2;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isButtonPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isButtonPressed = false;
        }
    }
}



