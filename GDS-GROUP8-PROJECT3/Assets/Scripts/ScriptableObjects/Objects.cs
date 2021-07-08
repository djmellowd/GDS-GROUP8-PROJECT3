using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerBullet", menuName = "ScriptableObjects/Objects", order = 1)]
public class Objects : ScriptableObject
{
 public int rangeToClick = 5;
    public KeyCode button;
}
