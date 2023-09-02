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

    public BoolVariable isLeftDoorClosed;
    //public bool isLeftDoorClosed = false;
    public bool isRightDoorClosed = false;

    // Start is called before the first frame update
    void Start()
    {
        isLeftDoorClosed.value = false;
        OpenLeftDoor();
        OpenRightDoor();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && powerLevel.value > 0)
        {
            isLeftDoorClosed.value = !isLeftDoorClosed.value;
            print("LEFT DOOR");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && powerLevel.value > 0)
        {
            isRightDoorClosed = !isRightDoorClosed;
            print("RIGHT DOOR");
        }

        if (isLeftDoorClosed.value) CloseLeftDoor();
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
        isLeftDoorClosed.value = false;
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
