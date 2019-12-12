using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public enum CameraType { PLAYER_LOCKED, ROOM_LOCKED }
    public static CameraType currentType = CameraType.ROOM_LOCKED;
    Vector3 rot;
    Vector3 currentPos;
    Room currentRoom;
    float cameraSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, GameData.cameraHeight + 5, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentType)
        {
            case CameraType.ROOM_LOCKED:
                if (Player.currentRoom != Player.prevRoom && Player.prevRoom != null)
                {
                    transform.position = Vector3.Lerp(transform.position, Player.currentRoom.cameraPos, 2 * Time.deltaTime);
                }
                break;
            case CameraType.PLAYER_LOCKED:

                //transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(3, 3, 3);
                transform.LookAt(GameObject.FindWithTag("Player").transform);

                break;

        }

        Debug.Log(currentType);
   


    }

    public void ZoomIn()
    {
        GetComponent<Camera>().fieldOfView -= 0.5f;
    }

    public void ZoomOOut()
    {
        GetComponent<Camera>().fieldOfView += 0.5f;

    }

    public void MoveUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1 * Time.deltaTime, transform.position.z);

    }

    public void MouveDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1 * Time.deltaTime, transform.position.z);
    }

    public void CollapseWalls()
    {
        Ray[] ray = new Ray[5];
        for (int x = 0; x < ray.Length; x++)
        {
            if (x < 3)
            {
                ray[x] = Camera.main.ScreenPointToRay(new Vector2(-50 * x, -50));
                RaycastHit hit;
                bool hasHit = Physics.Raycast(ray[x], out hit);
                if (hasHit)
                {
                    if (hit.collider.tag == "walll")
                    {
                       hit.transform.gameObject.SetActive(false);
                    }
                   
                }

            }
            else
            {
                ray[x] = Camera.main.ScreenPointToRay(new Vector2(50 * x, -50));
                RaycastHit hit;
                bool hasHit = Physics.Raycast(ray[x], out hit);
                if (hasHit)
                {
                    if (hit.collider.tag == "walll")
                    {
                       hit.transform.gameObject.SetActive(false);
                    }
                   
                }
            }

        }



    }
}
