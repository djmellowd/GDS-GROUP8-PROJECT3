﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : MonoBehaviour
{
    [SerializeField] private Transform leftPart;
    [SerializeField] private Transform rightPart;
    [SerializeField] private float deviation = 0;
    [SerializeField] private int speed;

    [Header("Otwieranie")] 
    [SerializeField] private bool button1;
    [SerializeField] private bool button2;
    [SerializeField] private bool button3;

    private Vector3 _leftDir;
    private Vector3 _rightDir;
    private GameContoller gameContoller;

    private void Awake()
    {
        gameContoller = FindObjectOfType<GameContoller>();

        _leftDir = new Vector3(leftPart.position.x - deviation, leftPart.position.y, leftPart.position.z);
        _rightDir = new Vector3(rightPart.position.x + deviation, rightPart.position.y , rightPart.position.z);      
    }
    private void Update()
    {
        if (gameContoller.MiniGameControler[0].UnlockWin && gameContoller.MiniGameControler[1] && gameContoller.MiniGameControler[2])
        {
            OpenDoor();
        }
    }
    private void OpenDoor()
    {
        leftPart.position = Vector3.MoveTowards(leftPart.position, _leftDir, speed * Time.deltaTime);
        rightPart.position = Vector3.MoveTowards(rightPart.position, _rightDir, speed * Time.deltaTime);
    }
}
