using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Infinite02 : MonoBehaviour
{
   
    [SerializeField] Transform OtherRoadSpawnPoint;
    [SerializeField] Road_Speed roadSpeed;
    

    void Update()
    {
        float Translate = roadSpeed.RoadSpeed;
        gameObject.transform.Translate(0, -Translate, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("RoadRespawn"))
        {
            gameObject.transform.position = new Vector2(OtherRoadSpawnPoint.position.x, OtherRoadSpawnPoint.position.y);
        }
    }
}
