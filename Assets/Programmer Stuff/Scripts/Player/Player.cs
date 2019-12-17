using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    /*===========================
            VARIABLES           
    =========================== */
    public static Room currentRoom;
    public static Room prevRoom;
    [SerializeField] int speed;
    [SerializeField] Transform[] cameraPositions;
    Vector3 initOffset;
    Camera mainCamera;
    [SerializeField] GameObject clickParticle;

    [SerializeField] Transform target;

    //puzzle room start positions
    public float prsX;
    public float prsY;
    public float prsZ;

    public int machineState;

    CameraScript_2 camScript;

    private GameObject go;

    public GameObject upperStairArrow;
    public GameObject downStairArrow;
    //============================


    // Start is called before the first frame update
    void Start()
    {
        camScript = Camera.main.GetComponent<CameraScript_2>();
        initOffset = Camera.main.transform.position - transform.position;
        mainCamera = Camera.main;
        target = null;
       // currentRoom = GameObject.FindWithTag("MainRoom").GetComponent<Room>();
       
    }

    // Update is called once per frame
    void Update()
    {


        Debug.Log(currentRoom);
        if (prevRoom != null)
        {
            Debug.Log(prevRoom);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(machineState);
        }


       

        //if (machines != null)
        //{
        //    foreach (GameObject machine in machines)
        //    {

        //        if (machine.GetComponent<Machine>().currentState == Machine.MachineState.BROKEN)
        //        {
        //            GameData.machines.Add(machine.GetComponent<Machine>());
        //        }
        //    }
        //}

        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     if (currentLocation == Status.IN)
        //     {
        //         currentLocation = Status.OUT;
        //     }
        //     else
        //     {
        //         currentLocation = Status.IN;
        //     }
        // }
        // switch (GameData.currentGameMode)
        // {
        //     case GameData.GameMode.EDIT:

        //         if (Input.GetKey(KeyCode.LeftArrow))
        //         {
        //             CameraMovement.Rotate(mainCamera, transform, cameraSpeed);
        //         }
        //         if (Input.GetKey(KeyCode.RightArrow))
        //         {
        //             CameraMovement.Rotate(mainCamera, transform, -cameraSpeed);
        //         }
        //         if (Input.GetKey(KeyCode.I))
        //         {
        //             mainCamera.GetComponent<CameraScript>().ZoomIn();
        //         }
        //         if (Input.GetKey(KeyCode.O))
        //         {
        //             mainCamera.GetComponent<CameraScript>().ZoomOOut();
        //         }
        //         if (Input.GetKey(KeyCode.UpArrow))
        //         {
        //             mainCamera.GetComponent<CameraScript>().MoveUp();
        //         }
        //         if (Input.GetKey(KeyCode.DownArrow))
        //         {
        //             mainCamera.GetComponent<CameraScript>().MouveDown();
        //         }

        //         break;
        // }

        // switch (currentLocation)
        // {
        //     case Status.REPAIR:
        //         Debug.Log("Entering repair status");
        //         break;
        // }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            machineState = 2;

        if (Input.GetKey(KeyCode.D))
            machineState = 3;

        // if (Input.GetKey(KeyCode.A))
        //     transform.Translate(Vector3.left * 2 * Time.deltaTime);

        // if (Input.GetKey(KeyCode.S))
        //     transform.Translate(Vector3.back * 2 * Time.deltaTime);

        // if (Input.GetKey(KeyCode.D))
        //     transform.Translate(Vector3.right * 2 * Time.deltaTime);

        if (Input.GetMouseButton(0)) MoveToCursor();
        if (target != null) GetComponent<NavMeshAgent>().destination = target.position;
    }

    public void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            if (hit.transform.tag == "Ground")
            {
                Debug.Log("enemy hit");
                GetComponent<NavMeshAgent>().stoppingDistance = 0f;
                GetComponent<NavMeshAgent>().destination = hit.point;
            }
            else
            {
                GetComponent<NavMeshAgent>().stoppingDistance = 0f;
                GetComponent<NavMeshAgent>().destination = hit.point;
                Instantiate(clickParticle, new Vector3(hit.point.x,hit.point.y + 0.2f , hit.point.z), Quaternion.identity);

            }
            if (hit.transform.tag == "UpperArrow")
            {
                GetComponent<NavMeshAgent>().destination = downStairArrow.transform.position;
            }

            if(hit.transform.tag == "DownArrow")
            {
                GetComponent<NavMeshAgent>().destination = upperStairArrow.transform.position;
            }
          
        }


    }


    //Dylans floor script
    //resets the player to the begining of the room if they touch the bad part of the floor
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "resetFloor" && machineState != 1)
        //{
        //    transform.position = new Vector3(prsX, prsY, prsZ);
        //    GetComponent<NavMeshAgent>().SetDestination(transform.position);

        //}

        if (collision.gameObject.tag == "Arrow")
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
            


    }

   

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        {

            for (int a = 0; a < col.gameObject.transform.childCount; a++)
            {
                col.gameObject.transform.GetChild(a).gameObject.SetActive(true);
            }

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        {
            CameraScript_2.cameraPos = new Vector3(col.GetComponent<MeshRenderer>().bounds.center.x, camScript.cameraHeight[1], col.GetComponent<MeshRenderer>().bounds.center.z);

        }

        if (col.gameObject.tag == "resetFloor" && machineState != 1)
        {
            transform.position = new Vector3(prsX, prsY, prsZ);
            GetComponent<NavMeshAgent>().SetDestination(transform.position);

        }

        go = GameObject.FindWithTag("Room");

        if (col.gameObject.name == "ExitTrigger")
        {
           
            if (machineState == 2 || machineState == 3)
            {
                Destroy(go);
                GameObject.Find("Room Spawn point").GetComponent<PuzzleRoomRandomSpawn>().SpawnRoom();
            }
        }

        //if (col.gameObject.name == "EnterTrigger")
        //{
        //    GameObject.Find("Room Spawn point").GetComponent<PuzzleRoomRandomSpawn>().playerRoom = 2;
        //}

    }

    
    
}
