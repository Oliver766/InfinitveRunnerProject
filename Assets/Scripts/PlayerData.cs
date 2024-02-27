using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// script reference - coco  - https://www.youtube.com/watch?v=QyskStWVd9g
// script by oliver lancashire
// sid - 1901981
public class Data
{
    [Header("Floats")]
    public float distance;
    [Header("ints")]
    public int score;
    public int DeathCounter;

    /// <summary>
    /// function to set data
    /// </summary>
    /// <param name="distance"></param>
    /// <param name="DeathCounter"></param>
    /// <param name="score"></param>
    public Data(float distance, int DeathCounter, int score)
    {
        this.distance = distance;
        this.DeathCounter = DeathCounter;
        this.score = score;
    }
}

public class PlayerData : MonoBehaviour
{
    [Header("References")]
    public PlayerController playerController;
    public Score _score;

    /// <summary>
    ///  return data set
    /// </summary>
    /// <returns></returns>
    public Data ReturnClass()
    {
        return new Data(playerController.distance, playerController.deathCounter, _score.score);
    }

  
}
