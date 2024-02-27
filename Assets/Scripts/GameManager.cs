using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
// script by oliver lancashire
// sid - 1901981
public class GameManager : MonoBehaviour
{
    [Header("int")]
    public static int number = 0;
    [Header("Game object")]
    public GameObject MCanvas;
    public GameObject GameOBJ;
    public GameObject HUD;
    public GameObject pause_Obj;

    public void Start()
    {
        // checks if number is 1
        if (number == 1)
        {
            MCanvas.SetActive(false);
            GameOBJ.SetActive(true);
            HUD.SetActive(true);
            Time.timeScale = 1;
            Cursor.visible = false;
        }
        // checks if number is 0
        else if (number == 0)
        {
            MCanvas.SetActive(true);
            GameOBJ.SetActive(false);
            HUD.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = true;
        }
    }
    public void Update()
    {
        // press escape to pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void CursonVis()
    {
        Cursor.visible = false;
    } 

    /// <summary>
    ///    text increases if cursor hovers
    /// </summary>
    public void OnHoverEnter(TextMeshProUGUI text)
    {
        text.fontSize = 62;
    }

    /// <summary>
    ///   text decreases if cursor hovers exit
    /// </summary>
    public void OnHoverExit(TextMeshProUGUI text)
    {
        text.fontSize = 60;
    }

    /// <summary>
    /// load games
    /// </summary>
    public void LoadScene()
    {
        number = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// loads main menu
    /// </summary>
    public void LoadMainScene()
    {
        number = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// pause game
    /// </summary>
    public void Pause()
    {
        pause_Obj.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0;
        Cursor.visible = true;
    }
    /// <summary>
    /// un pause game
    /// </summary>
    public void Resume()
    {
        pause_Obj.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    /// <summary>
    /// function to quit game
    /// </summary>
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
