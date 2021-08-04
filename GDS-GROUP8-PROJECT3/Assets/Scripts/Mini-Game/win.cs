using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{

    public string sceneName6;

    void OnTriggerEnter(Collider other)
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName6);
    }
}