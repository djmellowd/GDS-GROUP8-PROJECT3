using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        textInBox.text = text;
        boxCanvas.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(WaitForHideBox(timeToHide));
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
