using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Singleton
{
    private static string MAIN_GAME_SCENE = "Level";
    private static string GAME_OVER_SCENE = "GameOverScene";

    public void GoToMainGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MAIN_GAME_SCENE);
    }

    public void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GAME_OVER_SCENE);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
