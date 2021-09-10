using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGun : MonoBehaviour
{
    [Header("Patrol")]
    [SerializeField] private int patrolRange;
    [SerializeField] private int patrolSpeed;
    [SerializeField] private float offSetPatrol;
    
    [Header("Shoot")]
    [SerializeField] private GameObject barrel;
    [SerializeField] private int rottateBarrelSpeed = 650;

    private float startRotationY;
    private float rotationParameter;

    private Quaternion leftRotation;
    private Quaternion rightRotation;
    private bool swapRotate;

    void Awake()
    {
        startRotationY = transform.rotation.y;
        leftRotation = Quaternion.Euler(-90, 180 + patrolRange, 0);
        rightRotation = Quaternion.Euler(-90, 180 - patrolRange, 0);

        InvokeRepeating("SwtichRotate", 0, offSetPatrol);
    }

    private void Start()
    {
       
    }

    void Update()
    {
        Patrol();
        //RotateBarrel();
    }

    private void Patrol()
    {
        
        if (swapRotate)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, leftRotation, patrolSpeed * Time.deltaTime);
        }
        else
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rightRotation, patrolSpeed * Time.deltaTime);
        }
        
    }
    private void SwtichRotate()
    {
        if (swapRotate)
        {
            swapRotate = false;
        }
        else
        {
            swapRotate = true;
        }
    }
    private void RotateBarrel()
    {
         //rotationParameter =+   Time.time* patrolSpeed;
        barrel.transform.localRotation =  Quaternion.Euler(rottateBarrelSpeed, -90, 90);
    }
}
