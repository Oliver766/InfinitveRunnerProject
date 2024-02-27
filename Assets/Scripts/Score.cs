using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// script reference - sloo  - https://www.youtube.com/watch?v=4MCAYdhu5LY
// script by oliver lancashire
// sid - 1901981s
public class Score : MonoBehaviour
{
    [Header("ints")]
    public int score = 0;
    [Header("UI")]
    public TextMeshProUGUI scoreText;
    [Header("References")]
    public PlayerController PlayerController;

    void Update()
    {
        // saves and gets high score
        if (PlayerController.isGameover)
        {
            if(PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HightScore",score);
                Debug.Log("New high score is" + score);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checks if player collides with big cactus
        if (collision.gameObject.CompareTag("BigCactus"))
        {
            score = score + 3;
            scoreText.text =  score.ToString();
        }
        // checks if player collides with small cactus
        if (collision.gameObject.CompareTag("Small Cactus"))
        {
            score = score + 2;
            scoreText.text = score.ToString();
        }
        // checks if player collides with crate
        if (collision.gameObject.CompareTag("Crate"))
        {
            score = score + 4;
            scoreText.text = score.ToString();
        }
    }
}
