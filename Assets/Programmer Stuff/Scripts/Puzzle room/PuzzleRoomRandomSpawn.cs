using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRoomRandomSpawn : MonoBehaviour
{

    public GameObject[] Rooms;
    public int room;

    public int workingState;

    public bool playerLeftRoom;
    public bool hasRoomSpawned;

    public int playerRoom;   // 1 = main room, 2 = puzzle room


    private GameObject go;


    // Start is called before the first frame update
    void Start()
    {
        room = UnityEngine.Random.Range(0, 4);

        Instantiate(Rooms[room], new Vector3(0,0,0), Quaternion.identity);
        hasRoomSpawned = true;

        go = GameObject.FindWithTag("Room");


        //workingState = GameObject.Find("Player").GetComponent<Player>().machineState;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(go);
            hasRoomSpawned = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
            workingState = 2;

        if (Input.GetKeyDown(KeyCode.A))
            workingState = 3;



        if (workingState == 2 || workingState == 3)
        {
            if(playerRoom == 1)
            {
                Destroy(go);
                hasRoomSpawned = false;

                if (hasRoomSpawned == false)
                {
                    room = UnityEngine.Random.Range(0, 4);
                    Instantiate(Rooms[room], new Vector3(0, 0, 0), Quaternion.identity);
                    hasRoomSpawned = true;
                }                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindWithTag("Player"))
        {
            playerLeftRoom = true;
        }
    }
}
