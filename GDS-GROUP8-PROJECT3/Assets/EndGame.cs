using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private float time;

    private void Awake()
    {
        StartCoroutine(EndCutScene());
    }

    IEnumerator EndCutScene()
    {
        yield return new WaitForSeconds(time);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuNew");
    }
}
