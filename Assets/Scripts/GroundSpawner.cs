using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// script reference - sloo  - https://www.youtube.com/watch?v=4MCAYdhu5LY
// script by oliver lancashire
// sid - 1901981
public class GroundSpawner : MonoBehaviour
{
    [Header("Game object")]
    public GameObject Ground1, Ground2, Ground3;
    [Header("bools")]
    private bool hasGround = true;

    void Update()
    {
        //checks bool then spawn ground
        if (!hasGround)
        {
            SpawnGround();
            hasGround = true;
        }
    }

    /// <summary>
    /// function that randomises platforms
    /// </summary>
    public void SpawnGround()
    {
        int randomNum = Random.Range(1, 4);
        if(randomNum == 1)
        {
            Instantiate(Ground1, new Vector3(transform.position.x + 3, -4.17f, 0), Quaternion.identity);
        }
        if (randomNum == 2)
        {
            Instantiate(Ground2, new Vector3(transform.position.x + 3, -2.05f, 0), Quaternion.identity);
        }
        if (randomNum == 3)
        {
            Instantiate(Ground3, new Vector3(transform.position.x + 3, -1.04f, 0), Quaternion.identity);
        }
    }

    /// <summary>
    /// checks if game object enters the  ground
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = true;
        }
    }
    /// <summary>
    /// checks if objects exisited trigger
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = false;
        }
    }
}

  

