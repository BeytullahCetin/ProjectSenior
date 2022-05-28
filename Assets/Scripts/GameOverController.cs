using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] int delayAfterReload = 5;
    [SerializeField] AudioClip gameOverClip;
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
        SoundManager.Instance.GetComponent<AudioListener>().enabled = true;
        SoundManager.Instance.PlayClip(gameOverClip);
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(delayAfterReload);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
