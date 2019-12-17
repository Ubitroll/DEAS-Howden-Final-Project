using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixMachine : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")    //lets the player fix the machine as he stands within the fixing hitbox
        {
            GameObject.Find("Machine").GetComponent<Machine>().currentState = Machine.MachineState.WORKING;
            GameObject.Find("Machine").GetComponent<Machine>().lifeTime = Random.Range(10, 23);
            GameObject.Find("Machine").GetComponent<Machine>().timer.timeLeft = Random.Range(8, 16);
            GameObject.FindWithTag("UpperArrow").SetActive(false);
            GameObject.FindWithTag("DownArrow").SetActive(true);

        }
    }
}
