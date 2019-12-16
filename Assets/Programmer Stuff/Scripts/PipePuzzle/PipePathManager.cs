using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePathManager : MonoBehaviour
{
    // Variables
    public Camera cam; // Set to the camera that overlooks the puzzle

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
    }
}
