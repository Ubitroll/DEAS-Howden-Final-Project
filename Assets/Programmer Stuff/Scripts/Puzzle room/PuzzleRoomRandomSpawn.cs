﻿using System.Collections;
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


        room = UnityEngine.Random.Range(0, 4);  //randomly chooses between all 5 room prefabs
        
        if (prevRoom == room)   //makes sure it wont spawn the same room twice in a row
        {
            room = UnityEngine.Random.Range(0, 4);
            Instantiate(Rooms[room], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
            Instantiate(Rooms[room], new Vector3(0, 0, 0), Quaternion.identity);    //spawns the randomly chosen room

        room = prevRoom;

    }

   
}
