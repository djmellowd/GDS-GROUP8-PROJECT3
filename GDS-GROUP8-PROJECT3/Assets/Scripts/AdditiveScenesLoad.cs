using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveScenesLoad : MonoBehaviour
{
    [SerializeField] private List<string> sceneName;
    void Awake()
    {
        foreach (var item in sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(item, LoadSceneMode.Additive);
        }
    }
}
