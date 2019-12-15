using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePathManager : MonoBehaviour
{
    // VAriables
    public Camera cam;

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
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Pipe")
                {
                    hit.transform.Rotate(90, 0, 0);

                    hit.collider.GetComponent<PipePieceScript>().currentRotation = hit.collider.GetComponent<PipePieceScript>().currentRotation + 1;

                    if (hit.collider.GetComponent<PipePieceScript>().currentRotation > 4)
                    {
                        hit.collider.GetComponent<PipePieceScript>().currentRotation = 1;
                    }
                }
            }
        }
    }
}
