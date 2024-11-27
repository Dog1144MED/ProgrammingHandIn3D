using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGameManager : MonoBehaviour
{
    public GameObject[] obstacles;

    public Vector3[] spawnPoints;
    public Vector3 spawnVector;
    int spawnAmount;

    public float interval = 2f; // Time interval in seconds
    private float elapsedTime = 0f;


    void Update()
    {
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;
        // Check if the interval has passed
        if (elapsedTime >= interval)
        {
            SpawnObject();       // Call the function
            elapsedTime = 0f;
            if (interval > 1)
            {
                interval -= 0.1f;
            }
        }

    }
    public void SpawnObject()
    {
        //gør sådan at den kun spawner en hvis mængde randomly

        foreach (Vector3 spawnP in spawnPoints)
        {
            switch (Random.Range(0, obstacles.Length))
            {
                case 0: GameObject obs = Instantiate(obstacles[0], spawnP, Quaternion.Euler(spawnVector.x, spawnVector.y, spawnVector.z)); obs.tag = "Point"; break;
                case 1: GameObject obstacle = Instantiate(obstacles[1], spawnP, Quaternion.Euler(spawnVector.x, spawnVector.y, spawnVector.z)); obstacle.tag = "Obstacle"; break;
            }

        }
    }
}
