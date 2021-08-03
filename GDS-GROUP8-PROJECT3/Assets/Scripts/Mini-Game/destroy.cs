using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroy : MonoBehaviour
{

    public string sceneName5;

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName5);
    }
}
