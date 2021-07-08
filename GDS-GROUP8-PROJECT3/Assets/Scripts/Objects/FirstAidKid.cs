using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tactical;

public class FirstAidKid : MonoBehaviour
{

    [SerializeField] private Objects scriptableObject;
    [SerializeField] private BasicData playerData;
    private const string NamePlayer = "Player";


    private int regen;

    private void Awake()
    {
        regen = scriptableObject.hpRegen;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == NamePlayer)
        {
            var player = collision.gameObject.GetComponent<Health>();
            PlayerInteraction(player);
        }
    }

    private void PlayerInteraction(Health playerHp)
    {
        playerHp.RegenHp(regen);
        gameObject.SetActive(false);
    }
}
