using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    [SerializeField] float SpawnRate;
    [SerializeField] GameObject obstacle;
    [SerializeField] Road_Speed road;
    BoxCollider2D collider;
    float timer;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        SpawnObstacle();
    }


    void Update()
    {
       
        timer += Time.deltaTime* road.BaseSpeed;
        if (timer >= SpawnRate)
        {
            timer = 0;
            SpawnObstacle();
        }

    }
    void SpawnObstacle()
    {
        var Obstacle = Instantiate(obstacle, GetRandomPointInsideCollider2(collider), Quaternion.Euler(0, 0, 0));
    }
    public Vector2 GetRandomPointInsideCollider2(BoxCollider2D boxCollider)
    {
        Vector2 extents = boxCollider.size / 2f;
        Vector2 point = new Vector2(
            Random.Range(-extents.x, extents.x),
            Random.Range(-extents.y, extents.y)
        );

        return boxCollider.transform.TransformPoint(point);
    }
}
