using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private Renderer mRenderer;
    public bool openDoor;
    [SerializeField] private bool mainDoor;
    [SerializeField] private List<Renderer> parts;
    [SerializeField] private Objects scriptableObject;
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

        mRenderer.material.color = Color.gray;
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!openDoor)
            {
                openDoor = true;
                if (mainDoor)
                {
                    foreach (var VARIABLE in parts)
                    {
                        VARIABLE.material.color = Color.green;
                    }
                }
            }
            else
            {
                openDoor = false;
            }
        }
    }


    private void OnMouseExit()
    {
        mRenderer.material.color = Color.black;
    }
}
