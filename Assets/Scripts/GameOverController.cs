using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    Canvas gameOverCanvas;

    void Reset()
    {
        gameOverCanvas = GetComponent<Canvas>();
    }

    void Start()
    {
        gameOverCanvas = GetComponent<Canvas>();
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
}