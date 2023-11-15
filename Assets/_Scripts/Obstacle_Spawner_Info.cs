using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner_Info : MonoBehaviour
{
    public float horizontalDirection;
    public enum CrossingDirection
    {
        right, left, none,
    }
    public CrossingDirection SpawnedCrossingDirection = CrossingDirection.none;

    void Start()
    {
        switch (SpawnedCrossingDirection)
        {
            case CrossingDirection.left:
                horizontalDirection = -1;
                break;
            case CrossingDirection.right:
                horizontalDirection = 1;
                break;
            case CrossingDirection.none:
                horizontalDirection = 0;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
