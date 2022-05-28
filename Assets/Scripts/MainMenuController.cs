using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] string newGameScene;
    [SerializeField] SlidingText storyScreen;
    [SerializeField] Button pressAnyKey;

    public void NewGame()
    {
        StartStory();
    }

    void SkipStartingScene()
    {
        if(Keyboard.current.anyKey.wasPressedThisFrame)
        {
            pressAnyKey.onClick.Invoke();
        }
    }

    void LoadGameAfterStory()
    {
        SceneManager.LoadScene(newGameScene);
    }

    void StartStory()
    {
        storyScreen.gameObject.SetActive(true);
        storyScreen.StartSlideText();
        storyScreen.OnTextEnd += LoadGameAfterStory;
    }

    public void Quit()
    {
        //Quit
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
