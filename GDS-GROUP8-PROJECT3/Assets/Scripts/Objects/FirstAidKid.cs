using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tactical;

public class FirstAidKid : MonoBehaviour
{
    private const string audioString = "FirstKidPickUp";
    [SerializeField] private Objects scriptableObject;
    private const string NamePlayer = "Player";


    private int regen;
    private AudioManager audioManager;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        regen = scriptableObject.hpRegen;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == NamePlayer)
        {
            var player = collision.gameObject.GetComponent<Health>();
            PlayerInteraction(player);
            audioManager.Play(audioString);
        }
    }

    private void PlayerInteraction(Health playerHp)
    {
        playerHp.RegenHp(regen);
        gameObject.SetActive(false);
    }
}
