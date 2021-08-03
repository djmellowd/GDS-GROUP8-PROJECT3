using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveScenesLoad : MonoBehaviour
{
    public string sceneName;
    public string sceneName2;
    public string sceneName3;
    void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName2, LoadSceneMode.Additive);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName3, LoadSceneMode.Additive);
    }
}
