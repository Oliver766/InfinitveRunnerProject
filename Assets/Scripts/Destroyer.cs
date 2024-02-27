using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// script reference - sloo  - https://www.youtube.com/watch?v=4MCAYdhu5LY
// script by oliver lancashire
// sid - 1901981
public class Destroyer : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if player colides  with obstacles
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
        // if player colides  with obstacles
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(collision.gameObject);
        }
    }
}
