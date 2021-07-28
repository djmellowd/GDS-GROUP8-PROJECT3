using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy",menuName ="ScriptableObjects/BasicData", order = 1)] 
public class BasicData : ScriptableObject
{
    [Header("Ogólne")]
    public float health;
    
    [Header("Tylko dla gracza")]
    public float speed = 12;
    public float gravity = -9.81f;
}
