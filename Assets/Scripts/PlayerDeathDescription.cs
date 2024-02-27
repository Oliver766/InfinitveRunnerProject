using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// script reference - sloo  - https://www.youtube.com/watch?v=4MCAYdhu5LY
// script by oliver lancashire
// sid - 1901981
public class PlayerDeathDescription : MonoBehaviour
{
    [Header("UI")]
    public string OutputDescription;
    // Start is called before the first frame update
    void Start()
    {
        // output response
        OutputDescription = "Currently null";
    }

    // Update is called once per frame
    void Update()
    {
        // debug response
        Debug.Log(OutputDescription);

    }
}

