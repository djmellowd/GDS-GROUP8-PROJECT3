using BehaviorDesigner.Runtime.Tactical;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string SceneName = "Additive Scene 2";

    private AsyncOperation LoadLevelOperation = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != null && LoadLevelOperation == null)
        {
            LoadLevelOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        }
    }
}
