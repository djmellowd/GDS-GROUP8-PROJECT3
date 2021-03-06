using System;
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
    private Material gunFragmentRender;
    [SerializeField]
    private Transform parentAmmo;
    [SerializeField]
    private GameObject ammoPreFab;
    [SerializeField]
    private HudManager hudManager;

    private List<GameObject> ammoList = new List<GameObject>();
    private float timeToFire;
    private Vector3 destination;
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

    private void Overheating()
    {
        if (Input.GetMouseButton(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / bullet.fireRate;

            if (resetGun < bullet.limitAmmo)
            {
                StopAllCoroutines();
                resetGun += 1;
                Shooting();
                StartCoroutine(TimeBetweenShoots());
                hudManager.RefreshOverheatPlayer(resetGun);
            }
            else
            {
                hudManager.RefreshOverheatPlayer(resetGun);
                gunFragmentRender.color = Color.red;
            }
        }
    }


    IEnumerator TimeBetweenShoots()
    {
        yield return new WaitForSeconds(bullet.overheatingTime);
        gunFragmentRender.color = Color.black;
        resetGun = 0;
        hudManager.RefreshOverheatPlayer(resetGun);
    }

    private void Shooting()
    {
        for (int i = 0; i < ammoList.Count; i++)
        {
            if (!ammoList[i].activeInHierarchy)
            {
                Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    destination = hit.point;
                }

                ammoList[i].transform.position = spawnPoint.transform.position;
                ammoList[i].transform.rotation = gameObject.transform.rotation;
                var rbAmmo = ammoList[i].GetComponent<PlayerLaser>();
                rbAmmo.direction = destination;
                rbAmmo.starPos = spawnPoint.position;
                ammoList[i].SetActive(true);
                return;
            }
        }
    }

}
