using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainGun : MonoBehaviour
{
    private const string OVERHEAT_STRING = "Overheat";

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
    [SerializeField]
    private GameObject muzzlePrefab;
    [SerializeField]
    private HudManager hudManager;

    private List<GameObject> ammoList = new List<GameObject>();   
    private Vector3 destination;
    private float timeToFire;
    private float resetGun;
    private float normalGunFov;
    private float smoothFovTransition;
    private bool playAudioOverheat =false;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
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
        if (resetGun >= bullet.limitAmmo)
        {
            gunFragmentRender.materials[0].color = Color.red;
            if (!playAudioOverheat)
            {
                audioManager.Play(OVERHEAT_STRING);
                playAudioOverheat = true;
            }
           
            return;
        }
        if (Input.GetMouseButton(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / bullet.fireRate;
            StopAllCoroutines();
            resetGun += 1;
            hudManager.RefreshOverheatPlayer(resetGun);
            Shooting();
            StartCoroutine(TimeBetweenShoots());

        }
    }


    IEnumerator TimeBetweenShoots()
    {
        yield return new WaitForSeconds(bullet.overheatingTime);
        gunFragmentRender.materials[0].color = Color.yellow;
        playAudioOverheat = false;
        resetGun = 0;
        hudManager.RefreshOverheatPlayer(0);
    }

    private void Shooting()
    {
        for (int i = 0; i < ammoList.Count; i++)
        {
            if (!ammoList[i].activeInHierarchy)
            {
                Instantiate(muzzlePrefab, spawnPoint.transform.position, transform.rotation, spawnPoint.transform.parent);

                Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    destination = hit.point;
                }

                ammoList[i].transform.position = spawnPoint.transform.position;
                ammoList[i].transform.rotation = gameObject.transform.rotation;
                var rbAmmo = ammoList[i].GetComponent<movee>();
                rbAmmo.direction = destination;
                rbAmmo.starPos = spawnPoint.position;
                ammoList[i].SetActive(true);
                return;
            }
        }
    }

}
