﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    [SerializeField] [TextArea(1, 4)] private string textInBox;
    [SerializeField] private float timeToHide;
    [SerializeField] private AudioSource audioSource;

    [HideInInspector] public TextBoxManager TextBoxManager;

    private bool firstAwake = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!firstAwake)
        {
            if (other.gameObject.tag == PLAYER_TAG)
            {
                audioSource.Play();
                firstAwake = true;
                TextBoxManager.ActiveBox(textInBox, timeToHide);
            }
        }    
    }
}
