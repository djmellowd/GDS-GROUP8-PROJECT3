﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainGun : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private PlayerBullet bullet;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Renderer gunFragmentRender;
    [SerializeField]
    private Transform parentAmmo;
    [SerializeField]
    private GameObject ammoPreFab;

    private List<GameObject> ammoList = new List<GameObject>();
    private float timeToFire;
    private int resetGun;
    private float normalGunFov;
    private float smoothFovTransition;

    void Awake()
    {
        normalGunFov = mainCamera.fieldOfView;

        PullObjectAmmo();
    }
    void Update()
    {
        Overheating();
        Aiming();
    }

    private void PullObjectAmmo()
    {
        for (int i = 0; i < bullet.limitAmmo; i++)
        {
            GameObject ammo = Instantiate(ammoPreFab);
            ammo.transform.parent = parentAmmo;
            ammoList.Add(ammo);
            ammo.SetActive(false);
        }
    }  

    private void Aiming()
    {
        if (Input.GetMouseButton(1))
        {
            var value = Mathf.Lerp(normalGunFov, bullet.aimingFov, smoothFovTransition);
            mainCamera.fieldOfView = value;
            smoothFovTransition += 8 * Time.deltaTime;
        }
         if (Input.GetMouseButtonUp(1))
        {
            smoothFovTransition = 0;
            mainCamera.fieldOfView = normalGunFov;
        }       
    }

    private void Overheating()
    {
        if (Input.GetMouseButton(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / bullet.fireRate;

            if (resetGun < bullet.limitAmmo)
            {
                StopAllCoroutines();
                resetGun += 1;
                SetActiveBullet();
                StartCoroutine(TimeBetweenShoots());
            }
            else
            {
                gunFragmentRender.materials[0].color = Color.red;
            }
        }
    }

    IEnumerator TimeBetweenShoots()
    {
        yield return new WaitForSeconds(bullet.overheatingTime);
        gunFragmentRender.materials[0].color = Color.yellow;
        resetGun = 0;
    }

    private void SetActiveBullet()
    {
        for (int i = 0; i < ammoList.Count; i++)
        {
            if (!ammoList[i].activeInHierarchy)
            {
                ammoList[i].transform.position = spawnPoint.transform.position;
                ammoList[i].SetActive(true);
                return;
            }
        }
    }
}
