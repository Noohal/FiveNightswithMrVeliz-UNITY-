using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicaAI : MonoBehaviour
{
    public IntVariable currentTime;
    public int lastHourTime = 0;

    public Transform body;
    public string[] movementPointTags = {"8C", "UM", "UB", "6", "2a", "4", "RD", "InRightOffice", "DeathSpot"};
    public Transform[] movementPoints;

    public float lastMovementTime = 0;
    public const float MOVEMENT_INTERVAL = 5f;

    public BoolVariable isMoving;
    public BoolVariable isRightDoorClosed;

    public int[] startingAILevels = { };
    public int currentAILevel;

    public int currentLocation = 0;
    public int lastLocation = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Transform>();
        currentAILevel = 10;

        SetMovementPoints();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementPoints == null || movementPoints.Length == 0)
            print("CHICA MOVEMENT POINTS");

        if(currentTime.value != lastHourTime)
        {
            switch (currentTime.value)
            {
                case 3:
                case 4:
                    currentAILevel += 1;
                    break;
                default:
                    break;
            }
        }

        float now = Time.time;
        if(now - lastMovementTime >= MOVEMENT_INTERVAL)
        {
            int currentRoll = Random.Range(1, 20);
            if(currentAILevel >= currentRoll)
            {
                StartCoroutine(Move());
            }
            lastMovementTime = now;
        }

        lastHourTime = currentTime.value;
    }

    IEnumerator Move()
    {
        isMoving.value = true;

        lastLocation = currentLocation;
        currentLocation = CalculateNewDestination(lastLocation);

        yield return new WaitForSeconds(3f);

        body.transform.position = movementPoints[currentLocation].transform.position;
        isMoving.value = false;
    }

    int CalculateNewDestination(int _lastLocation)
    {
        int newDest = 0;
        int chance = 0;

        /**
         * 0 - Cam 8
         * 1 - UM
         * 2 - UB
         * 3 - Cam 6
         * 4 - Cam 2a
         * 5 - Cam 4
         * 6 - Door
         * 7 - Inside Office
         */

        switch(_lastLocation)
        {
            case 0:
                newDest = 1;
                break;
            case 1:
                chance = Random.Range(1, 10);
                if(chance <= 5)
                {
                    newDest = 2;
                }
                else
                {
                    newDest = 3;
                }
                break;
            case 2:
                chance = Random.Range(1, 10);
                if(chance <= 5)
                {
                    newDest = 3;
                }
                else
                {
                    newDest = 4;
                }
                break;
            case 3:
                chance = Random.Range(1, 10);
                if(chance <= 5)
                {
                    newDest = 2;
                }
                else
                {
                    newDest = 4;
                }
                break;
            case 4:
                chance = Random.Range(1, 10);
                if(chance <= 2)
                {
                    newDest = 1;
                }
                else
                {
                    newDest = 5;
                }
                break;
            case 5:
                chance = Random.Range(1, 10);
                if(chance <= 4)
                {
                    newDest = 4;
                }
                else
                {
                    newDest = 6;
                    print("Chica Ready to Attack");
                }
                break;
            case 6:
                newDest = Attack();
                break;
            default:
                print("INVALID");
                break;
        }

        if (newDest == 0)
            newDest = lastLocation;

        print("Chica: Moving to " + newDest);
        return newDest;
    }

    int Attack()
    {
        return isRightDoorClosed.value ? 4 : 7;
    }

    public void SetMovementPoints()
    {
        Transform[] tempPoints = new Transform[9];
        for(int i = 0; i < movementPointTags.Length; i++)
        {
            tempPoints[i] = GameObject.FindGameObjectWithTag(movementPointTags[i]).transform;
        }
        movementPoints = tempPoints;
    }
}
