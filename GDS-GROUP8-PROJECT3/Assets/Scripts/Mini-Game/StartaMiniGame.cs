using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartaMiniGame : MonoBehaviour
{
    [SerializeField] private Renderer mRenderer;
    public bool openDoor;
    [SerializeField] private bool mainDoor;
    [SerializeField] private List<Renderer> parts;
    [SerializeField] private Objects seriaObject;
    public Camera[] cameras;
    private int currentCameraIndex;

    private AudioManager audioManager;
    private int rangeToClick;

    [SerializeField] GameObject GO;
    [SerializeField] GameObject GO2;
    [SerializeField] GameObject GO3;
    [SerializeField] GameObject GO4;
    [SerializeField] GameObject GO5;
    [SerializeField] GameObject GO6;

    private void Awake()
    {
        rangeToClick = seriaObject.rangeToClick;
    }

    private void Start()
    {
        currentCameraIndex = 0;

        //Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        //If any cameras were added to the controller, enable the first one
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
        }
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
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                GO.SetActive(true);
                GO2.SetActive(true);
                GO3.SetActive(true);
                GO4.SetActive(true);
                GO5.SetActive(false);
                GO6.SetActive(false);
                currentCameraIndex++;
                if (currentCameraIndex < cameras.Length)
                {
                    cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                    cameras[currentCameraIndex].gameObject.SetActive(true);
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
                    cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                    currentCameraIndex = 0;
                    cameras[currentCameraIndex].gameObject.SetActive(true);
                    openDoor = false;
                }
            }
        }
    }

    private void OnMouseExit()
    {
        mRenderer.material.color = Color.black;
    }
}
