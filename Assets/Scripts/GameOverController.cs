using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    Canvas gameOverCanvas;

    void Reset()
    {
        gameOverCanvas = GetComponent<Canvas>();
    }

    void Start()
    {
        Reset();
        gameOverCanvas.enabled = false;
    }

    void OnEnable()
    {
        Enemy.OnGameOver += GameOver;
    }

    void OnDisable()
    {
        Enemy.OnGameOver -= GameOver;
    }

    void GameOver()
    {
        gameOverCanvas.enabled = true;
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
