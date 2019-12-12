using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRoomRandomSpawn : MonoBehaviour
{

    public GameObject[] Rooms;
    public int room;

    // Start is called before the first frame update
    void Start()
    {
        room = UnityEngine.Random.Range(0, 0);

        Instantiate(Rooms[room], new Vector3(0,0,0), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
       //if ( aaa == ClassName.MachineState)
    }
}
