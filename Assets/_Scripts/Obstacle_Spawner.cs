
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    [SerializeField] float SpawnRate;   
    [SerializeField] float SpawnAdvance;   
    [SerializeField] float SpawnedSpeed;   
    [SerializeField] GameObject obstacle;
    [SerializeField] Road_Speed road;
    [SerializeField] bool InitialSpawn;
    public BoxCollider2D[] colliders;
    BoxCollider2D CurrentCollider;
    float timer;
    public int ghdgfhdfh;
    public enum DificultyLevel
    {
        lvl01,lvl02, lvl03,
    }
    DificultyLevel CurrentLevel;


    [Serializable]
    public class DificultyLevelClass
    {
        public DificultyLevel lvl;
        public float SpawnRate;
        public float DistanceRequired;
    }
    public DificultyLevelClass[] dificultyClasses;

    void Start()
    {
        
        if(InitialSpawn) SpawnObstacle();

        timer = SpawnAdvance;
        UpdateDificulty();
       

    }
    void Update()
    {
       
        timer += Time.deltaTime* road.BaseSpeed;
        if (timer >= SpawnRate)
        {
            timer = 0;
            
            SpawnObstacle();
            CheckDistanceForDifficulty();
            UpdateDificulty();
        }

    }
     BoxCollider2D PickRandomCollider()
    {
        int randomInt = UnityEngine.Random.Range(0, colliders.Length);
        Debug.Log(randomInt);
        return colliders[randomInt];
    }
    void SpawnObstacle()
    {
        CurrentCollider = PickRandomCollider();
        GameObject Obstacle = Instantiate(obstacle, GetRandomPointInsideCollider2(CurrentCollider), Quaternion.Euler(0, 0, 0));
        Obstacle_Behaviour SpawnedBehaviour = Obstacle.GetComponent<Obstacle_Behaviour>();
        SpawnedBehaviour.horizontalAxis = CurrentCollider.GetComponent<Obstacle_Spawner_Info>().horizontalDirection;
        SpawnedBehaviour.horizontalSpeed = SpawnedSpeed;
    }
    public Vector2 GetRandomPointInsideCollider2(BoxCollider2D boxCollider)
    {
        Vector2 extents = boxCollider.size / 2f;
        Vector2 point = new Vector2(
            UnityEngine.Random.Range(-extents.x, extents.x),
            UnityEngine.Random.Range(-extents.y, extents.y)
        );

        return boxCollider.transform.TransformPoint(point);
    }
    void UpdateDificulty()
    {
        switch (CurrentLevel)
        {
            case DificultyLevel.lvl01:
                SpawnRate = dificultyClasses[0].SpawnRate;
                break;
            case DificultyLevel.lvl02:
                SpawnRate = dificultyClasses[1].SpawnRate;
                break;
            case DificultyLevel.lvl03:
                SpawnRate = dificultyClasses[2].SpawnRate;
                break;
        }
    }
    void CheckDistanceForDifficulty()
    {
        if ((road.TraveledDistance > dificultyClasses[0].DistanceRequired) || ( road.TraveledDistance > 0));
        {
            CurrentLevel = dificultyClasses[0].lvl;
        }
        if (road.TraveledDistance > dificultyClasses[1].DistanceRequired)
        {
            CurrentLevel = dificultyClasses[1].lvl;
        }
        if (road.TraveledDistance > dificultyClasses[2].DistanceRequired)
        {
            CurrentLevel = dificultyClasses[2].lvl;
        }
    }
}
