using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
// script reference - sloo  - https://www.youtube.com/watch?v=4MCAYdhu5LY
// script by oliver lancashire
// sid - 1901981
public class PlayerController : MonoBehaviour
{
    [Header("Floats")]
    public float runSpeed;
    public float distance;
    public float x;
    public float y;
    public float z;
    [Header("ints")]
    public static int number = 0;
    private int jumpCount = 0;
    public int deathCounter;
    [Header("bools")]
    private bool canJump = true;
    public bool isGameover;
    [Header("Animation")]
    Animator animator;
    [Header("References")]
    public PlayfabManager manager;
    public Score score;
    [Header("UI")]
    public TextMeshProUGUI scoretxt;
    public TextMeshProUGUI distancetxt;
    public TextMeshProUGUI distanceUI;
    public PlayerDeathDescription deathDescription;
    [Header("Game object")]
    public GameObject player;
    public GameObject Canvas;
    public GameObject MCanvas;
    public GameObject HUD;
    [Header("rigidbody")]
    Rigidbody2D rb2d;
    void Start()
    {
        // get's component
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // start coroutine
        StartCoroutine("IncreaseGameSpeed");
        // same variable
        PlayerPrefs.SetInt("DeathCounter", deathCounter);
    }
    void Update()
    {
        //  running distance and diplay as UI
        if( isGameover == false)
        {
            distanceUI.text = distance.ToString("F0");
            distance += Time.deltaTime * 0.8f;
        }
        // if game is not over player moves to the right.
        if (!isGameover)
        {
            transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
        }
        // checks amount of jumps.
        if(jumpCount == 2)
        {
            canJump = false;
        }
        // press space to jump
        if (Input.GetKeyDown("space"))
        {
            Jump();        
        }
    }

    /// <summary>
    ///  game over function
    /// </summary>
    public void Gameover()
    {
        isGameover = true;
        animator.SetTrigger("death");
        StopCoroutine("IncreaseGameSpeed");
        Canvas.SetActive(true);
        manager.RecordEvent();
        distancetxt.text = distance.ToString("F0");
        scoretxt.text = score.score.ToString();
        HUD.SetActive(false);
        manager.SendLeaderBoard(score.score);
        manager.SaveData();
        Cursor.visible = true;
    }

    /// <summary>
    /// fucntion when player collides with object 
    /// </summary>
    public void FallOver()
    {
        isGameover = true;
        x = player.transform.position.x;
        y = player.transform.position.y;
        z = player.transform.position.z;
        deathCounter = PlayerPrefs.GetInt("DeathCounter");
        animator.SetTrigger("death");
        StopCoroutine("IncreaseGameSpeed");
        Canvas.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // checks if player collides with floor
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            canJump = true;
        }
        // checks if player collides  with big cactus 
        if (collision.gameObject.CompareTag("BigCactus"))
        {
            Gameover();
            deathCounter += 1;
            deathDescription.OutputDescription = "You died colliding with big cactus";
        }
        // checks if player colliders with small cactus 
        if (collision.gameObject.CompareTag("Small Cactus"))
        {
            Gameover();
            deathCounter += 1;
            deathDescription.OutputDescription = "You died colliding with small cactus";
        }
        // checks if player colliders with crate
        if (collision.gameObject.CompareTag("Crate"))
        {
            Gameover();
            deathCounter += 1;
            deathDescription.OutputDescription = "You died colliding with crate";
        }

    }

    /// <summary>
    /// checks if player colliders with game object 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndBottom"))
        {
            deathDescription.OutputDescription = "You died falling of platform";
            FallOver();
        }
    }

    /// <summary>
    /// function that slowly increases speed
    /// </summary>
    /// <returns></returns>
    IEnumerator IncreaseGameSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            if(runSpeed < 8)
            {
                runSpeed += 0.2f;
            }

           if( GameObject.Find("Ground Spawner").GetComponent<ObstacleSpawner>().obstacleSpawnInterval > 1)
            {
                GameObject.Find("Ground Spawner").GetComponent<ObstacleSpawner>().obstacleSpawnInterval -= 0.1f;
            }
        }
    }
    /// <summary>
    /// jump functions
    /// </summary>
    public void Jump()
    {
        if ( canJump && !isGameover)
        {
            rb2d.velocity = Vector3.up * 7.5f;
            animator.SetTrigger("Jump");
            jumpCount += 1;
        }
    }
}
