using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 12;
    [SerializeField] private float gravity = -9.81f;
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    
    private Vector3 _velocity;
    private bool _isGrounded;
    void Update()
    {
        FallCheck();
        MainMovement();
    }
    private void FallCheck()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y<0)
        {
            _velocity.y = -2f;
        }
    }
    private void MainMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed* Time.deltaTime);
        _velocity.y += gravity * Time.deltaTime;
        characterController.Move(_velocity * Time.deltaTime); 
    }
}
