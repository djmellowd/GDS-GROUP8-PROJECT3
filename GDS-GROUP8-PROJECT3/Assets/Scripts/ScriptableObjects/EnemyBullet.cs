using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyBullet", menuName = "ScriptableObjects/EnemyBullet", order = 1)]
public class EnemyBullet : ScriptableObject
{
    public int LimitAmmo;
    public float damage = 20;
    public float speed = 5;
    public float selfDestructTime = 5;
}
