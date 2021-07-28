using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    private const String DOOR_STRING = "Door";

    public bool openDoor;

    [SerializeField] private Renderer mRenderer; 
    [SerializeField] private bool mainDoor;
    [SerializeField] private List<Renderer> parts;
    [SerializeField] private Objects seriaObject;

    private AudioManager audioManager;
    private int rangeToClick;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();

        rangeToClick = seriaObject.rangeToClick;
    }
    private void OnMouseOver()
    {
        if (Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) > rangeToClick)
        {
            mRenderer.material.color = Color.black;
            return;
        }

        mRenderer.material.color = Color.gray;
        if (Input.GetKeyDown(seriaObject.button))
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
            audioManager.Play(DOOR_STRING);
        }
    }

    private void OnMouseExit()
    {
        mRenderer.material.color = Color.black;
    }
}
