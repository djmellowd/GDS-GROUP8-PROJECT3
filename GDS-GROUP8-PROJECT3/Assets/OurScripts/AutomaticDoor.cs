using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    [SerializeField] private Transform leftPart;
    [SerializeField] private Transform rightPart;
    [SerializeField] private float deviation=0;
    [SerializeField] private int speed;

    [Header("Otwieranie")] 
    [SerializeField] private bool onTrigger;
    [SerializeField] private bool OnButton;
    [SerializeField] private DoorButton button;

    private bool _closeDoor;
    private Vector3 _leftDir;
    private Vector3 _rightDir;
    private Vector3 _leftStart;
    private Vector3 _rightStart;
    private void Awake()
    {
        _leftStart = leftPart.position;
        _rightStart = rightPart.position;
        
        _leftDir = new Vector3(leftPart.position.x-deviation,leftPart.position.y,leftPart.position.z);
        _rightDir = new Vector3(rightPart.position.x+deviation,rightPart.position.y,rightPart.position.z);
    }

    private void OnTriggerStay(Collider other)
    {
        if (onTrigger)
        {
            if (other.tag == "Player")
            {
                _closeDoor = false;
                OpenDoor();
            }  
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (onTrigger)
        {
            if (other.tag == "Player")
            {
                _closeDoor = true;
            } 
        }
    }

    private void Update()
    {
        if (OnButton)
        {
            if (button.openDoor)
            {
                OpenDoor();
            } 
        }
        if (_closeDoor ||!button.openDoor)
        {
           CloseDoor();
        }
    }

    private void OpenDoor()
    {
        leftPart.position = Vector3.MoveTowards( leftPart.position,_leftDir,speed*Time.deltaTime);
        rightPart.position = Vector3.MoveTowards(rightPart.position,_rightDir,speed*Time.deltaTime);
    }

    private void CloseDoor()
    {
        Vector3 currentPosLeft = leftPart.position;
        Vector3 currentPosRight = rightPart.position;
        leftPart.position = Vector3.MoveTowards(currentPosLeft,_leftStart,speed*Time.deltaTime);
        rightPart.position = Vector3.MoveTowards(currentPosRight,_rightStart,speed*Time.deltaTime);
    }
}
