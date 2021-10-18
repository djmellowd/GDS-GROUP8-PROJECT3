using BehaviorDesigner.Runtime.Tactical;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGun : MonoBehaviour
{
    private const int RESET_TIMER = 0;
    [Header("Patrol")]
    [SerializeField] private int patrolRange;
    [SerializeField] private int patrolSpeed;
    [SerializeField] private float offSetPatrol;
    
    [Header("Barrel")]
    [SerializeField] private GameObject barrel;
    [SerializeField] private int rottateBarrelSpeed = 650;
    [SerializeField] private Health health;

    [Header("Shoot")]
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float shootingFrequency;

    private Quaternion leftRotation;
    private Quaternion rightRotation;
    private float rotationParameter;
    private bool swapRotate;
    private GameObject player;
    private GameContoller gameContoller;

    private List<GameObject> ammoList = new List<GameObject>();
    private float timer;

    public bool StartAtack;
    public bool IsDestory = false;
    private bool firstAwake;

    void Awake()
    {
        leftRotation = Quaternion.Euler(0, 180 + patrolRange, 0);
        rightRotation = Quaternion.Euler(0, 180 - patrolRange, 0);

        InvokeRepeating("SwtichRotate", 0, offSetPatrol);
        ObjectPullAmmo();
    }

    private void Start()
    {
        gameContoller = FindObjectOfType<GameContoller>();
        player = gameContoller.Player;
    }

    void Update()
    {
        if (!StartAtack)
        {
            timer = RESET_TIMER;
            Patrol();
        }
        else
        {
            if (!firstAwake)
            {
                health.enabled = true;
                firstAwake = true;
            }

            Shoot();
        }      
    }

    private void ObjectPullAmmo()
    {
        for (int i = 0; i < ammoPrefab.GetComponent<EnemyAmmoInGame>().EnemyBullet.LimitAmmo; i++)
        {
            GameObject ammo = Instantiate(ammoPrefab);
            ammo.GetComponent<EnemyAmmoInGame>().Player = player;
            ammoList.Add(ammo);
            ammo.SetActive(false);
        }
    }

    private void Shoot()
    {
        LookAtPlayer();
        RotateBarrel();

        timer += Time.deltaTime;
        if (timer >= shootingFrequency)
        {
            timer = RESET_TIMER;
            GameObject ammo = Instantiate(ammoPrefab);
            ammo.transform.position = spawnPoint.position;
            ammo.transform.rotation = gameObject.transform.localRotation;
            return;
        }       
    }

    private void LookAtPlayer()
    {
        var lookPos = player.transform.position - transform.position;
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
        barrel.transform.localRotation =  Quaternion.Euler(0, 0, rotationParameter);
    }
}
