using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public IntVariable powerLevel;
    public Transform leftDoor;
    public Transform rightDoor;

    public const float Y_CLOSED = 0.5f;
    public const float Y_OPEN = 3.5f;

    public bool isLeftDoorClosed = false;
    public bool isRightDoorClosed = false;

    // Start is called before the first frame update
    void Start()
    {
        OpenLeftDoor();
        OpenRightDoor();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && powerLevel.value > 0)
        {
            isLeftDoorClosed = !isLeftDoorClosed;
            print("LEFT DOOR");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && powerLevel.value > 0)
        {
            isRightDoorClosed = !isRightDoorClosed;
            print("RIGHT DOOR");
        }

        if (isLeftDoorClosed) CloseLeftDoor();
        else OpenLeftDoor();

        if (isRightDoorClosed) CloseRightDoor();
        else OpenRightDoor();
    }

    void CloseLeftDoor()
    {
        leftDoor.transform.position = new Vector3(leftDoor.transform.position.x, Y_CLOSED, leftDoor.transform.position.z);
    }

    void OpenLeftDoor()
    {
        leftDoor.transform.position = new Vector3(leftDoor.transform.position.x, Y_OPEN, leftDoor.transform.position.z);
    }

    void CloseRightDoor()
    {
        rightDoor.transform.position = new Vector3(rightDoor.transform.position.x, Y_CLOSED, rightDoor.transform.position.z);
    }

    void OpenRightDoor()
    {
        rightDoor.transform.position = new Vector3(rightDoor.transform.position.x, Y_OPEN, rightDoor.transform.position.z);
    }
}
