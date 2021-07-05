using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private static SceneManager _instance;
    private static string _mainGameText = "Main";
    public static SceneManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SceneManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void GoToMainGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_mainGameText);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
