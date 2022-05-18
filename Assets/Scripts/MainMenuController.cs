using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] string newGameScene;
    [SerializeField] SlidingText storyScreen;

    public void NewGame()
    {
        //New Game
        //Show story then load level 1
        Debug.Log("New Game");
        StartStory();
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
        Debug.Log("Quit");
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
