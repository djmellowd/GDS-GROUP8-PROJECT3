using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGun : MonoBehaviour
{
    [Header("Patrol")]
    [SerializeField] private int patrolRange;
    [SerializeField] private int patrolSpeed;
    [SerializeField] private float offSetPatrol;
    
    [Header("Barrel")]
    [SerializeField] private GameObject barrel;
    [SerializeField] private int rottateBarrelSpeed = 650;

    [Header("Shoot")]
    [SerializeField] private GameObject ammo;
    [SerializeField] private float speedAmmo;
    [SerializeField] private float RangeToSeePlayer;

    private Quaternion leftRotation;
    private Quaternion rightRotation;
    private float rotationParameter;
    private bool swapRotate;
    private GameObject player;
    private GameContoller gameContoller;

    void Awake()
    {
        leftRotation = Quaternion.Euler(0, 180 + patrolRange, 0);
        rightRotation = Quaternion.Euler(0, 180 - patrolRange, 0);

        InvokeRepeating("SwtichRotate", 0, offSetPatrol);
    }

    private void Start()
    {
        gameContoller = FindObjectOfType<GameContoller>();
        player = gameContoller.Player;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= RangeToSeePlayer)
        {          
            Shoot();
        }
        else
        {
            Patrol();
        }      
    }

    private void Shoot()
    {
        LookAtPlayer();
        RotateBarrel();
    }

    private void LookAtPlayer()
    {
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rottateBarrelSpeed);
        
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
        rotationParameter =+   Time.time* rottateBarrelSpeed;
        barrel.transform.localRotation =  Quaternion.Euler(rotationParameter, -90, 90);
    }
}
