using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Speed : MonoBehaviour
{
    public float BaseSpeed;
    public float RoadSpeed;
    public float TraveledDistance;
    public float TimePassed;
    [SerializeField] TextMesh textMesh;

    void Update()
    {
        RoadSpeed = BaseSpeed * Time.deltaTime;
        TimePassed += Time.deltaTime;
        TraveledDistance += RoadSpeed * TimePassed * 0.1f;
        
        textMesh.text = (TraveledDistance.ToString("0.#") + " m");
    }
}
