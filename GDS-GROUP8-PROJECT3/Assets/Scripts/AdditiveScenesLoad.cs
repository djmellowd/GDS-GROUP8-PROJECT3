using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveScenesLoad : MonoBehaviour
{
    [SerializeField] private List<string> sceneName;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager.NormalGame)
        {
            foreach (var item in sceneName)
            {
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(item, LoadSceneMode.Additive);
            }
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName[0], LoadSceneMode.Additive);
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName[1], LoadSceneMode.Additive);
        }
        
    }
}
