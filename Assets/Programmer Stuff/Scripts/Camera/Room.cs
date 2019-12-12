using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    Vector3 a, b, c, d;
    public Vector3 cameraPos;

    Vector3[] per = new Vector3[4];
    [SerializeField] float cameraAngle;


    // Start is called before the first frame update

    Machine machine;
    void Start()
    {
        InitializeRoomCoordinates();

    }



    // Update is called once per frame
    void Update()
    {
        // if(Player.currentRoom == this)
        // {
        //     ActiveWalls(false);
        // }
        // else{
        //     ActiveWalls(true);
        // }
    }

    //Find useful room coordinates
    private void InitializeRoomCoordinates()
    {
        int childCount = gameObject.transform.childCount;
        int i = 0;
        while (i < childCount)
        {
            //Get Floor child
            Transform child = transform.GetChild(i);
            if (child.gameObject.tag == "Floor")
            {
                // MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
                // //Floor corners
                // a = meshRenderer.bounds.max - new Vector3(meshRenderer.bounds.size.x, 0, 0);
                // b = meshRenderer.bounds.min;
                // c = meshRenderer.bounds.min + new Vector3(meshRenderer.bounds.size.x, 0, 0);
                // d = meshRenderer.bounds.max;

                for (int x = 0; x < per.Length; x++)
                {
                    per[x] = GetPerimeter(child)[x];
                }

                //Fixed position for camera in room
                cameraPos = GetCameraRoomPos(child);

            }

            i++;
        }
    }

    void OnDrawGizmos()
    {
        //Draw sphere in camera room position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(cameraPos, 0.1f);



        //Draw Room Perimeter
        // Gizmos.color = Color.red;
        // Gizmos.DrawLine(a + new Vector3(0, 0.2f, 0), d + new Vector3(0, 0.2f, 0));
        // Gizmos.DrawLine(a + new Vector3(0, 0.2f, 0), b + new Vector3(0, 0.2f, 0));
        // Gizmos.DrawLine(b + new Vector3(0, 0.2f, 0), c + new Vector3(0, 0.2f, 0));
        // Gizmos.DrawLine(c + new Vector3(0, 0.2f, 0), d + new Vector3(0, 0.2f, 0));
        Gizmos.color = Color.red;

        for (int x = 0; x < 4; x++)
        {
            if (x == 3) Gizmos.DrawLine(per[x] + new Vector3(0, -0.2f, 0), per[0] + new Vector3(0, -0.2f, 0)); else Gizmos.DrawLine(per[x] + new Vector3(0, -0.2f, 0), per[x + 1] + new Vector3(0, -0.2f, 0));

        }




    }

    public void DivideRoomInFour()
    {

    }

    public Vector3[] GetPerimeter(Transform obj)
    {
        Vector3[] p = new Vector3[4];
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        //Floor corners
        p[0] = meshRenderer.bounds.max - new Vector3(meshRenderer.bounds.size.x, 0, 0);
        p[1] = meshRenderer.bounds.min;
        p[2] = meshRenderer.bounds.min + new Vector3(meshRenderer.bounds.size.x, 0, 0);
        p[3] = meshRenderer.bounds.max;
        return p;
    }

    public Vector3 GetCameraRoomPos(Transform obj)
    {
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        return meshRenderer.bounds.min + new Vector3(meshRenderer.bounds.size.x,0,0) + new Vector3(-0.5f, GameData.cameraHeight , 0.5f);
    }


    //public void ActiveWalls(bool state)
    // {


    //     switch (state)
    //     {
    //         case true:
    //             for (int x = 0; x < walls.Length; x++)
    //             {
    //                 walls[x].SetActive(true);
    //             }
    //             break;
    //         case false:
    //             for (int x = 0; x < walls.Length; x++)
    //             {
    //                 walls[x].SetActive(false);
    //             }
    //             break;

    //     }
    // }
}
