using BehaviorDesigner.Runtime.Tactical;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmoInGame : MonoBehaviour
{
    [SerializeField] private EnemyBullet enemyBullet;
    [SerializeField] private Rigidbody rigidbody;

    public GameObject Player;
    public EnemyBullet EnemyBullet=> enemyBullet;

    void Update()
    {
        rigidbody.MovePosition(rigidbody.position + enemyBullet.speed * transform.forward * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Player)
        {
            IDamageable damageable;
            if ((damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable) != null)
            {
                damageable.Damage(enemyBullet.damage);
            }
        }
        gameObject.SetActive(false);
    }
}
