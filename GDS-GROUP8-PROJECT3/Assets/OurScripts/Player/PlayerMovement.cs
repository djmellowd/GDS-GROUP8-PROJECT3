using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tactical;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{


    [Header("To fill")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private BasicData basicData;

    private Vector3 _velocity;
    private bool _isGrounded;
    void Update()
    {
        MainMovement();
    }
    
    private void MainMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(move * basicData.runningSpeed* Time.deltaTime);     
        }
        else
        {
            characterController.Move(move * basicData.speed* Time.deltaTime);     
        }
      
    }
}
