using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveScenesLoad : MonoBehaviour
{
    public string sceneName;
    void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
}
