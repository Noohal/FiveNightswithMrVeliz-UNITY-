using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxyAI : MonoBehaviour
{
    public IntVariable currentTime;
    public int lastHourTime = 0;

    public Transform body;
    public Transform[] movementPoints;

    public float lastMovementTime = 0;
    public const float MOVEMENT_INTERVAL = 5f;

    public BoolVariable isMoving;
    public BoolVariable isLeftDoorClosed;

    public int[] startingAILevels = { };
    public int currentAILevel;

    public int currentStage = 0;
    public int lastStage = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementPoints == null || movementPoints.Length == 0)
            print("FOXY");

        if(currentTime.value != lastHourTime)
        {
            switch(currentTime.value)
            {
                case 3:
                case 4:
                    currentAILevel += 1;
                    break;
                default:
                    break;
            }
        }
    }
}
