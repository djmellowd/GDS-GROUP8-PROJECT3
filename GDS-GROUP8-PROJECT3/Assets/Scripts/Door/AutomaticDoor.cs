using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    [SerializeField] private Transform leftPart;
    [SerializeField] private Transform rightPart;
    [SerializeField] private float deviation = 0;
    [SerializeField] private int speed;
    [SerializeField] private bool rotateDoorY;


    private Vector3 _leftDir;
    private Vector3 _rightDir;
    private Vector3 _leftStart;
    private Vector3 _rightStart;


    public bool FirstDoor;
    public bool DoorIsOpen = false;
    private bool canOpen = false;


    private void Awake()
    {
        _leftStart = leftPart.position;
        _rightStart = rightPart.position;

        if (rotateDoorY)
        {
            _leftDir = new Vector3(leftPart.position.x, leftPart.position.y, leftPart.position.z - deviation);
            _rightDir = new Vector3(rightPart.position.x, rightPart.position.y, rightPart.position.z + deviation);
        }
        else
        {
            _leftDir = new Vector3(leftPart.position.x + deviation, leftPart.position.y, leftPart.position.z);
            _rightDir = new Vector3(rightPart.position.x - deviation, rightPart.position.y, rightPart.position.z);
        }

    }

    private void Update()
    {
        if (!FirstDoor)
        {
            if (DoorIsOpen)
            {
                OpenDoor();
            }
            else
            {
                CloseDoor();
            }
        }     
    }

    private void OpenDoor()
    {
        leftPart.position = Vector3.MoveTowards(leftPart.position, _leftDir, speed * Time.deltaTime);
        rightPart.position = Vector3.MoveTowards(rightPart.position, _rightDir, speed * Time.deltaTime);
    }

    private void CloseDoor()
    {
        Vector3 currentPosLeft = leftPart.position;
        Vector3 currentPosRight = rightPart.position;
        leftPart.position = Vector3.MoveTowards(currentPosLeft, _leftStart, speed * Time.deltaTime);
        rightPart.position = Vector3.MoveTowards(currentPosRight, _rightStart, speed * Time.deltaTime);
    }
}
