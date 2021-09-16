using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmoInGame : MonoBehaviour
{
    [SerializeField] private EnemyBullet enemyBullet;
    [SerializeField] private Rigidbody rigidbody;

    public EnemyBullet EnemyBullet=> enemyBullet;

    void Update()
    {
        rigidbody.MovePosition(rigidbody.position + enemyBullet.speed * transform.forward * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
