using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public GameObject LeftDoor; 

    public GameObject RightDoor;


    public float DoorMovement = 0.1f; 

    public bool OpenDoor = false;

    public float TileSize = 2; 

    float leftClosed; 
    float rightClosed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftClosed = LeftDoor.transform.localPosition.x; 
        rightClosed = RightDoor.transform.localPosition.x;
        StartCoroutine(RunDoor()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        OpenDoor = true; 
    }

    private void OnTriggerExit(Collider other)
    {
        OpenDoor = false;
    }



    IEnumerator RunDoor()
    {
        while (true)
        {
            if (OpenDoor)
            {
                if (LeftDoor.transform.localPosition.x > leftClosed - TileSize )
                {
                    LeftDoor.transform.localPosition -= new Vector3(DoorMovement, 0); 
                }
                if (RightDoor.transform.localPosition.x < rightClosed + TileSize)
                {
                    RightDoor.transform.localPosition += new Vector3(DoorMovement, 0); 
                }
            }
            else
            {
                if (LeftDoor.transform.localPosition.x < leftClosed )
                {
                    LeftDoor.transform.localPosition += new Vector3(DoorMovement, 0);
                    if (LeftDoor.transform.localPosition.x > leftClosed)
                        LeftDoor.transform.localPosition = new Vector3(leftClosed, LeftDoor.transform.localPosition.y, LeftDoor.transform.localPosition.z); 
                }
                if (RightDoor.transform.localPosition.x > rightClosed )
                {
                    RightDoor.transform.localPosition -= new Vector3(DoorMovement, 0);
                    if (RightDoor.transform.localPosition.x < rightClosed)
                        RightDoor.transform.localPosition = new Vector3(rightClosed, RightDoor.transform.localPosition.y, RightDoor.transform.localPosition.z);

                }
            }

            yield return new WaitForSeconds(0.1f); 
        }
    }
}
