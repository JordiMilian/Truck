using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Behaviour : MonoBehaviour
{
    public float horizontalSpeed = 5; 
    public float horizontalAxis; 
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
        float velocity_Y = road.RoadSpeed ;
        float velocity_X = horizontalAxis * horizontalSpeed * Time.deltaTime;
        transform.Translate(velocity_X, -velocity_Y , 0);
    }
}
