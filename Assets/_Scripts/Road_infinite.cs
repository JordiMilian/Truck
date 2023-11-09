using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_infinite : MonoBehaviour
{
    public float RoadSpeed;
    Material sdfsd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Offset = Time.deltaTime * RoadSpeed;
        GetComponent<Renderer>().material.mainTextureOffset += new Vector2 (0, Offset);
    }
}
