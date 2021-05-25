using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerBullet",menuName ="ScriptableObjects/PlayerBullet", order = 1)] 
public class PlayerBullet : ScriptableObject
{
   [Header("Gun")]
   public float damage;
   public int limitAmmo;
   [Header("Bullet")]
   public float timeToDestory=1;
   public float bulletSpeed;
}
