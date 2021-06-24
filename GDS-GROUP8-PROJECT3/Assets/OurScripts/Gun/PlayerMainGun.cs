﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainGun : MonoBehaviour
{
    [SerializeField] private Transform barrel;
    [SerializeField] private PlayerBullet playerBullet;
    
    [SerializeField] private Camera cam;
    private float _startCam;
    [SerializeField] private float endCam = 30;
    private float t=0;
    
    
    [SerializeField] private GameObject gunNormal;
    [SerializeField] private GameObject gunOver;
    [Header("Ammo")] [SerializeField] private Transform parentAmmo;
    [SerializeField] private GameObject ammoPreFab;
    private List<GameObject> _ammoList = new List<GameObject>();
    private Vector3 _destination;
    private int _resetGun;

    void Awake()
    {
        _startCam = cam.fieldOfView;
            
        for (int i = 0; i < playerBullet.limitAmmo; i++)
        {
            GameObject ammo = Instantiate(ammoPreFab);
            ammo.transform.parent = parentAmmo;
            _ammoList.Add(ammo);
            ammo.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Overheating();
        }

        if (Input.GetMouseButton(1))
        {
            Aiming();
        }

        if (Input.GetMouseButtonUp(1))
        {
            t = 0;
            cam.fieldOfView = _startCam;
        }
    }

    private void Aiming()
    {
        Debug.Log(1);
        var value = Mathf.Lerp(_startCam, endCam, t);
        cam.fieldOfView = value;
        t += 8 * Time.deltaTime;
    }
    private void Overheating()
    {
        if (_resetGun < playerBullet.limitAmmo)
        {
            StopAllCoroutines();
            _resetGun += 1;
            Shooting();
            StartCoroutine(TimeBetweenShoots());
        }
        else
        {
            gunNormal.gameObject.SetActive(false);
            gunOver.gameObject.SetActive(true);
        }
    }

    IEnumerator TimeBetweenShoots()
    {
        yield return new WaitForSeconds(playerBullet.overheatingTime);
        gunNormal.gameObject.SetActive(true);
        gunOver.gameObject.SetActive(false);
        _resetGun = 0;
    }

    private void Shooting()
    {
        for (int i = 0; i < _ammoList.Count; i++)
        {
            if (!_ammoList[i].activeInHierarchy)
            {
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    _destination = hit.point;
                }
                _ammoList[i].transform.position = barrel.transform.position;
                _ammoList[i].SetActive(true);
                var rbAmmo = _ammoList[i].GetComponent<PlayerBulletInGame>();
                rbAmmo.direction = _destination;
                return;
            }
        }
    }
}
