using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Obstacles;
    [SerializeField] float minCounter = 2f;
    [SerializeField] float maxCounter = 4f;
    [SerializeField] float minDistance = 4f;
    [SerializeField] float maxDistance = 6f;
    
 
    float counter = 2f;
    PlatformControl[] parent;


    private void Update()
    {
        parent = FindObjectsOfType<PlatformControl>();

        counter -= Time.deltaTime;

        SpawnObstacle();
        
    }

    private void SpawnObstacle()
    {
        if (counter >= 0) return;

        int obstacleIndex = Random.Range(0, Obstacles.Length);
        float yOffset = 0f;

        if(obstacleIndex == 4)
        {
            yOffset = Random.Range(0.2f, 0.6f);
        }
        else
        {
            yOffset = 0f;
        }

        GameObject obstacle = Instantiate(Obstacles[obstacleIndex],
            new Vector3(Random.Range(minDistance, maxDistance) + transform.position.x, 0.733f + yOffset, transform.position.z), Quaternion.identity);

        

        counter = Random.Range(minCounter, maxCounter);
    }

}
