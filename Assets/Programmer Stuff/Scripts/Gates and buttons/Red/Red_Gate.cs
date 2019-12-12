using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Gate : MonoBehaviour
{

    public bool isButtonPressed;
    public float destroyTimer;
    private bool gateOpen;


    // Update is called once per frame
    void Update()
    {

        isButtonPressed = GameObject.Find("red button").GetComponent<Red_Button>().isButtonPressed;

        if (isButtonPressed == true)
        {
            gateOpen = true;
            destroyTimer = 2;          
        }

        //sets the door to open and will continue to open even if the player isnt standing on the button
        if (gateOpen == true)
            transform.Translate(0, -2 * Time.deltaTime, 0);

        //destroys door to save cpu usage

        if (destroyTimer > 0)
            destroyTimer -= Time.deltaTime;

        if (destroyTimer < 0)
            Destroy(gameObject);
    }
}