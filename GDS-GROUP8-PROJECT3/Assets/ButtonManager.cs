using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ButtonManager : Singleton
{

    private static string _mainGameText = "Gameplay";
    private static string _mainMenuText = "MainMenuNew";

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToMainGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_mainGameText);
    }

    public void GoToMainMenu()
    {
        StartCoroutine(GoToMenu());
    }

    private IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(_mainMenuText);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
