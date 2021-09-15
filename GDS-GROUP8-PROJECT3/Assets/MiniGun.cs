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

    [Header("Shoot")]
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float shootingFrequency;
    [SerializeField] private float RangeToSeePlayer;
    [SerializeField] private float RedZone;

    private Quaternion leftRotation;
    private Quaternion rightRotation;
    private float rotationParameter;
    private bool swapRotate;
    private GameObject player;
    private GameContoller gameContoller;

    private List<GameObject> ammoList = new List<GameObject>();
    private float timer;

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
        var distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance >= RangeToSeePlayer || distance <= RedZone)
        {
            timer = RESET_TIMER;
            Patrol();
        }
        else
        {          
            Shoot();
        }      
    }

    private void ObjectPullAmmo()
    {
        for (int i = 0; i < ammoPrefab.GetComponent<EnemyAmmoInGame>().EnemyBullet.LimitAmmo; i++)
        {
            GameObject ammo = Instantiate(ammoPrefab);
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
            for (int i = 0; i < ammoList.Count; i++)
            {
                if (!ammoList[i].activeInHierarchy)
                {
                    ammoList[i].transform.position = spawnPoint.position;
                    ammoList[i].transform.rotation = gameObject.transform.localRotation;
                    ammoList[i].SetActive(true);
                    return;
                }
            }
        }          
    }

    private void LookAtPlayer()
    {
        var lookPos = player.transform.position - transform.position;
        lookPos.y += 1;
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
