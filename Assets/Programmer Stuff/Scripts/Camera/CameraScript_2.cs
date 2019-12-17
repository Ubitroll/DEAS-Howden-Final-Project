using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript_2 : MonoBehaviour
{
    public static Vector3 cameraPos;

    public float[] cameraHeight = new float[3];

    [SerializeField] GameObject mainRoom;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos =  new Vector3(mainRoom.GetComponent<MeshRenderer>().bounds.center.x,cameraHeight[1],mainRoom.GetComponent<MeshRenderer>().bounds.center.z);
        transform.position = Vector3.Lerp(transform.position, cameraPos, 2 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPos, 2 * Time.deltaTime);

    }
}
