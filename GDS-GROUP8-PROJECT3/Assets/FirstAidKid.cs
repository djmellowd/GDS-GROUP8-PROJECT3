using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKid : MonoBehaviour
{

    [SerializeField] private Objects scriptableObject;
    [SerializeField] private Renderer mRenderer;

    private int rangeToClick;
    private KeyCode interactionButton;
    private Color startColor;
    private void Awake()
    {
        rangeToClick = scriptableObject.rangeToClick;
        interactionButton = scriptableObject.button;

        startColor = mRenderer.material.color;
    }
    private void OnMouseOver()
    {
        if (Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) > rangeToClick)
        {
            mRenderer.material.color = startColor;
            return;
        }
        mRenderer.material.color = Color.gray;
        if (Input.GetKeyDown(interactionButton))
        {

        }
    }
    private void OnMouseExit()
    {
        mRenderer.material.color =startColor;
    }
}
