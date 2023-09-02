using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BonnieAi : MonoBehaviour
{
    public IntVariable currentTime;

    public Transform body;
    public Transform[] movementPoints;
    //public NavMeshAgent agent;

    /**
     * AI Calculations
     * Every movement interval, there is a movement opportunity.
     * Roll 1d20. Compare to current AI level.
     * If AI is >= random roll, then animatronic can move.
     */ 

    public float lastMovementTime = 0;
    public const float MOVEMENT_INTERVAL = 5;
    public BoolVariable isMoving;
    public BoolVariable isLeftDoorClosed;

    public int[] startingAILevels = { 0, 3, 0, 2, 5, 10 };
    public int currentAILevel;

    public int lastHourTime = 0;

    public int currentLocation = 0;
    public int lastLocation = 0;

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        body = GetComponent<Transform>();
        currentAILevel = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementPoints == null || movementPoints.Length == 0)
            print("MOVEMENTPOINTS");

        if(currentTime.value != lastHourTime)
        {
            switch(currentTime.value)
            {
                case 2:
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
        print("Moving to: " + currentLocation);

        yield return new WaitForSeconds(3f);
        
        body.transform.position = movementPoints[currentLocation].transform.position;
        isMoving.value = false;
        
        print("END MOVE");

        //agent.SetDestination(movementPoints[currentLocation].transform.position);
    }

    int CalculateNewDestination(int lastLocation)
    {
        int newDest = 0;

        /**
         * lastLoc --> 1, 2
         * 0 Cam 8   --> Cam 7, Cam 9
         * 1 Cam 7   --> Cam 1b, Cam 9
         * 2 Cam 9   --> Cam 1b, Cam 7
         * 3 Cam 1b  --> Cam 1a, Cam 3
         * 4 Cam 1a  --> Cam 3, Door
         * 5 Cam 3   --> Cam 1a, Door
         * 6 Door    --> Cam 9
         */

        /**
         * 0 - Cam 8
         * 1 - Cam 7
         * 2 - Cam 9
         * 3 - Cam 1b
         * 4 - Cam 1a
         * 5 - Cam 3
         * 6 - Door
         */

        int chance = 0;
        switch (lastLocation)
        {
            case 0:
                newDest = Random.Range(1, 2);
                break;
            case 1:
                chance = Random.Range(1, 2);
                if (chance == 1)
                {
                    newDest = 2;
                } else
                {
                    newDest = 3;
                }
                break;
            case 2:
                chance = Random.Range(1, 2);
                if (chance == 1)
                {
                    newDest = 3;
                }
                else
                {
                    newDest = 1;
                }
                break;
            case 3:
                chance = Random.Range(1, 2);
                if (chance == 1)
                {
                    newDest = 4;
                }
                else
                {
                    newDest = 5;
                }
                break;
            case 4:
                chance = Random.Range(1, 2);
                if (chance == 1)
                {
                    newDest = 5;
                }
                else
                {
                    newDest = 6;
                }
                break;
            case 5:
                chance = Random.Range(1, 2);
                if (chance == 1)
                {
                    newDest = 6;
                }
                else
                {
                    newDest = 4;
                }
                break;
            case 6:
                print("Ready to Attack");
                newDest = Attack();
                break;
            default:
                print("Invalid");
                break;
        }
        if (newDest == 0)
            newDest = lastLocation;
        return newDest;
    }

    int Attack()
    {
        return isLeftDoorClosed.value ? 2 : 7;
    }

    public void SetMovementPoints(Transform[] _movementPoints)
    {
        movementPoints = _movementPoints;
    }
}
