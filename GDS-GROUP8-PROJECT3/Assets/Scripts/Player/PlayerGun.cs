using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [Header("Basic Parameters")]
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    
    [Header("Objects")]
    [SerializeField] private Camera camera;

    [SerializeField] private ParticleSystem muzzleFlash;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        
        RaycastHit hitInfo;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, range))
        {
          Target target = hitInfo.transform.GetComponent<Target>();
          if (target != null)
          {
             target.TakeDamage(damage); 
          }
        }
        
    }
}
