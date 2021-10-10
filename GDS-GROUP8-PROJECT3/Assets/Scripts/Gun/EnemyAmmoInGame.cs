using BehaviorDesigner.Runtime.Tactical;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmoInGame : MonoBehaviour
{
    [SerializeField] private EnemyBullet enemyBullet;

    public GameObject Player;
    public EnemyBullet EnemyBullet=> enemyBullet;


    private void OnParticleCollision(GameObject other)
    {
        IDamageable damageable;
        if ((damageable = other.gameObject.GetComponent(typeof(IDamageable)) as IDamageable) != null)
        {
            damageable.Damage(enemyBullet.damage);
        }
        gameObject.SetActive(false);
    }
}
