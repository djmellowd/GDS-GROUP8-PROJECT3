using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    [SerializeField] private GameObject boxCanvas;
    [SerializeField] private TextMeshProUGUI textInBox;
    [SerializeField] private List<TextBox> texts;

    private void Awake()
    {
        foreach (var item in texts)
        {
            item.TextBoxManager = this;
        }
    }
    public void ActiveBox(string text, float timeToHide)
    {
        if (textInBox != null)
        {
            textInBox.text = text;
        }
        
        boxCanvas.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(WaitForHideBox(timeToHide));
    }

    public void StopAllAudio()
    {
        foreach (var item in texts)
        {
            item.AudioSource.Stop();
        }
    }

    IEnumerator WaitForHideBox(float time)
    {
        yield return new WaitForSeconds(time);
        HideBox();
    }
    private void HideBox()
    {
        boxCanvas.SetActive(false);
    }
}
