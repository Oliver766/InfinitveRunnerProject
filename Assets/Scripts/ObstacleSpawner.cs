using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// script reference - sloo  - https://www.youtube.com/watch?v=4MCAYdhu5LY
// script by oliver lancashire
// sid - 1901981
public class ObstacleSpawner : MonoBehaviour
{
    [Header("Game object")]
    public GameObject obstacle1, obstacle2, obstacle3;
    [Header("Floats")]
    public float obstacleSpawnInterval = 2.5f;
    [Header("References")]
    public PlayerController PlayerController;

    void Start()
    {
        // starts coroutine
        StartCoroutine("SpawnObstacles");
    }

    void Update()
    {
        // if game is over then start coroutine
        if (PlayerController.isGameover)
        {
            StopCoroutine("SpawnObstacles");
        }
    }

    /// <summary>
    /// randomise instantiation on objects function
    /// </summary>
    private void SpawnObstacle()
    {
        int random = Random.Range(1, 4);

        if(random == 1)
        {
            Instantiate(obstacle1, new Vector3(transform.position.x, -0.4f, 0), Quaternion.identity);
        }
        else if (random == 2)
        {
            Instantiate(obstacle2, new Vector3(transform.position.x, -0.4f ,0), Quaternion.identity);
        }
        else if (random == 3)
        {
            Instantiate(obstacle3, new Vector3(transform.position.x, -0.4f, 0), Quaternion.identity);
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(obstacleSpawnInterval);
        }
    }
}
