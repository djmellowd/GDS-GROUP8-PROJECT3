using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ButtonManager : Singleton
{
    private static string _mainGameText = "Gameplay";
    private AudioManager audioManager;

    public static ButtonManager instance;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
       
    }
    private void Start()
    {
        audioManager.Play("MenuMusic");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToMainGame()
    {
        audioManager.Stop("MenuMusic");
        audioManager.NormalGame = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(_mainGameText);
    }

    public void GoToMainGameEasy()
    {
        audioManager.Stop("MenuMusic");
        audioManager.NormalGame = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(_mainGameText);
    }
}
