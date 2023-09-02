using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement Points")]
public class MovementPointsVariable : ScriptableObject
{
    public int size;
    public Transform[] movementPoints;
}
