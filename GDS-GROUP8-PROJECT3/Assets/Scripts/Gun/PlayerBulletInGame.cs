using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tactical;
using UnityEngine;

public class PlayerBulletInGame : MonoBehaviour
{
    [SerializeField] private PlayerBullet playerBullet;
    [SerializeField] private Rigidbody m_Rigidbody;
    [SerializeField] public Transform StartPos;
    [HideInInspector]public Vector3 direction;
    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,direction,playerBullet.bulletSpeed*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        var enemy = other.gameObject.GetComponent<Health>();
        if (enemy!=null && other.gameObject.tag!="Player" )
        {
            enemy.Damage(playerBullet.damage);
        }

        if (other.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(playerBullet.timeToDestory);
        gameObject.SetActive(false);
    }
}
