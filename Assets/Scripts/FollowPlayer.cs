using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// script reference - sloo  - https://www.youtube.com/watch?v=4MCAYdhu5LY
// script by oliver lancashire
// sid - 1901981
public class FollowPlayer : MonoBehaviour
{
    [Header("Game object")]
    public GameObject player;
    [Header("vector 3")]
    private Vector3 offset;          
    // Start is called before the first frame update
    void Start()
    {
       // sets offset to be player position
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // position is new vector 3
        transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, transform.position.z);
    }
}
