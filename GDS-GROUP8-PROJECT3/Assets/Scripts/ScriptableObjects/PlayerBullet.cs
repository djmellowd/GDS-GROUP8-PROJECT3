using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerBullet",menuName ="ScriptableObjects/PlayerBullet", order = 1)] 
public class PlayerBullet : ScriptableObject
{
   public float damage;
   public float range;
}
