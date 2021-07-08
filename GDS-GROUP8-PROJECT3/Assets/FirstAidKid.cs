using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKid : MonoBehaviour
{

    [SerializeField] private Objects scriptableObject;
    [SerializeField] private Renderer mRenderer;
    private int rangeToClick;

    private void Awake()
    {
        rangeToClick = scriptableObject.rangeToClick;
    }
    private void OnMouseOver()
    {
        if (Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) > rangeToClick)
        {
            mRenderer.material.color = Color.black;
            return;
        }
    }
}
