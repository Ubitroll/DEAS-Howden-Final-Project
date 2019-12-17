using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRoomRandomSpawn : MonoBehaviour
{
    public GameObject[] Rooms;
    public int room;
    public int prevRoom = 0;

    void Start()
    {
        SpawnRoom();
    }

    public void SpawnRoom()
    {


        room = UnityEngine.Random.Range(0, 3);  //randomly chooses between all 5 room prefabs
        
        if (prevRoom == room)   //makes sure it wont spawn the same room twice in a row
        {
            room = UnityEngine.Random.Range(0, 3);
            Instantiate(Rooms[room], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }
        else
            Instantiate(Rooms[room], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);    //spawns the randomly chosen room

        prevRoom = room;

    }

   
}
