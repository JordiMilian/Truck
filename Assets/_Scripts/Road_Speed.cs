using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Speed : MonoBehaviour
{
    public float BaseSpeed;
    public float RoadSpeed;

    void Update()
    {
        RoadSpeed = BaseSpeed * Time.deltaTime;   
    }
}
