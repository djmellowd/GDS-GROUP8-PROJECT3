using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.Serialization;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSen =100f;
    private float _xRotation = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        MovementCamera();
    }
    private void MovementCamera()
    {
        var mouseX = Input.GetAxis("Mouse X") * mouseSen* Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y")* mouseSen * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
       // transform.localRotation = Quaternion.Euler(_xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
