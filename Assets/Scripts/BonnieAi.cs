using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BonnieAi : MonoBehaviour
{
    public Transform body;
    public Transform[] movementPoints;
    public NavMeshAgent agent;

    public float lastMovementTime = 0;
    public const float MOVEMENT_INTERVAL = 5;

    public const float MOVEMENT_OPPORTUNITY_CHANCE = 10f;
    public int currentLocation = 0;
    public int lastLocation = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Transform>();
        body.transform.position = movementPoints[0].position;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;
        if(now - lastMovementTime >= MOVEMENT_INTERVAL)
        {
            float currentChance = Random.Range(1, 20);

            // Check if there's a successful movement opportunity.
            if (currentChance >= MOVEMENT_OPPORTUNITY_CHANCE && agent.remainingDistance == 0)
            {
                print("Successful Move");
                // It's successful so move.
                Move();
            } else
            {
                print("Failed Move -- " + currentChance);
            }

            lastMovementTime = now;
        }

    }

    void Move()
    {
        lastLocation = currentLocation;
        currentLocation += 1;
        if(currentLocation >= movementPoints.Length)
        {
            currentLocation = 0;
        }
        agent.SetDestination(movementPoints[currentLocation].transform.position);
    }
}
