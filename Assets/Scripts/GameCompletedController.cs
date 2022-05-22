using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompletedController : MonoBehaviour
{
    public static GameCompletedController Instance;

    Canvas gameCompleted;

    [SerializeField] Canvas background;
    [SerializeField] SlidingText credits;
    [SerializeField] string mainMenuScene;
    [SerializeField] LevelController[] levelControllers;

    private void Awake()
    {
        if (null == Instance)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        gameCompleted = GetComponent<Canvas>();

    }

    public void CheckGameCompleted()
    {
        foreach (LevelController level in levelControllers)
        {
            if (false == level.IsLevelCompleted)
                return;
        }


        Debug.Log("Game End");
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        gameCompleted.enabled = true;
        yield return new WaitForSeconds(5);
        gameCompleted.enabled = false;
        background.enabled = true;
        StartCredits();
    }

    void LoadMainMenuAfterCredits()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    void StartCredits()
    {
        credits.gameObject.SetActive(true);
        credits.StartSlideText();
        credits.OnTextEnd += LoadMainMenuAfterCredits;
    }
}
