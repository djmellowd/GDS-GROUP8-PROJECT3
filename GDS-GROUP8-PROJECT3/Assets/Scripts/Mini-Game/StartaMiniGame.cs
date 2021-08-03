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

    private AudioManager audioManager;
    private int rangeToClick;

    public string sceneName4;

    private void Awake()
    {
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
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName4, LoadSceneMode.Additive);
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
