using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tactical;
using UnityEngine;

public class PlayerBulletInGame : MonoBehaviour
{
    [SerializeField] private PlayerBullet playerBullet;
    [HideInInspector]public Vector3 direction;
    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private void OnCollisionEnter(Collision other)
    {
        var enemy = other.gameObject.GetComponent<Health>();
        if (enemy!=null)
        {
            enemy.Damage(playerBullet.damage);
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(playerBullet.timeToDestory);
        gameObject.SetActive(false);
    }
}
