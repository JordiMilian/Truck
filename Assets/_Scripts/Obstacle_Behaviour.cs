using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Behaviour : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] float VerticalSpeed;
    [SerializeField] Road_Speed road;
    
    void Start()
    {
       
    }
    private void Awake()
    {
        road = GameObject.Find("RoadsManager").GetComponent<Road_Speed>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = road.RoadSpeed ;
        transform.Translate(0, -velocity , 0);
    }
}
