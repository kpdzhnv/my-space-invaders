using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool isPaused;
    public static float timeLeft;
    public GameObject targets;

    public UIManager uiM;

    void Awake()
    {
        isPaused = true;
        Time.timeScale = 0;
        timeLeft = 30.0f;

        uiM = FindObjectOfType(typeof(UIManager)) as UIManager;
        GenerateGame();
    }

    void Update()
    {
        if (!isPaused)
        {
            timeLeft -= Time.deltaTime;
            if (targets.transform.childCount == 0)
                Won();
            else if (timeLeft < 0)
                Failed();
        }
    }
    public void Won()
    {
        isPaused = true;
        Time.timeScale = 1;
    }
    public void Failed()
    {
        isPaused = true;
        Time.timeScale = 1;
    }

    public void Play()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void GenerateGame()
    {

    }
}
