using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tactical;
using UnityEngine;

public class PlayerGunRaycast : MonoBehaviour
{
    [Header("Basic Parameters")] 
    [SerializeField] private PlayerBullet playerBullet;
    
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
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, 100))
        {
            Debug.Log(hitInfo.collider.name);
          Health target = hitInfo.transform.GetComponent<Health>();
          if (target != null)
          {
             target.Damage(playerBullet.damage); 
          }
        }
        
    }
}
