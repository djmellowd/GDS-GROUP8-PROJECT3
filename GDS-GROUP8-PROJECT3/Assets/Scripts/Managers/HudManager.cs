using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tactical;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Collections;

public class HudManager : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    private int barsSpeed;

    [Header("Player HP")]
    [SerializeField]
    private Slider hpSlider;
    [SerializeField]
    private BasicData playerData;

    [Header("Damage Icons")]
    [SerializeField]
    private List<GameObject> damageIcons;

    [Header("Overheat")]
    [SerializeField]
    private Slider overheatSlider;
    [SerializeField]
    private PlayerBullet overheatData;

    private float _playerCurrentHp;
    private float _playerCurrentOverheat=0;

    private void Awake()
    {
        _playerCurrentHp = playerData.health;

        InitializationHealthPanel();
        InitializationOverheatPanel();
    }
    private void Update()
    {
        if (_playerCurrentHp != hpSlider.value)
        {
            hpSlider.value = Mathf.MoveTowards(hpSlider.value, _playerCurrentHp, barsSpeed * Time.deltaTime);
        }
        if ((overheatSlider.maxValue - _playerCurrentOverheat) != overheatSlider.value)
        {
            overheatSlider.value = Mathf.MoveTowards(overheatSlider.value,(overheatSlider.maxValue- _playerCurrentOverheat), barsSpeed * Time.deltaTime);
        }
    }

    private void InitializationHealthPanel()
    {
        hpSlider.maxValue = _playerCurrentHp;
        hpSlider.value = _playerCurrentHp;
    }

    private void InitializationOverheatPanel()
    {
        overheatSlider.maxValue = overheatData.limitAmmo;
        overheatSlider.value = overheatSlider.maxValue;
    }

    public void RefreshHpPlayer(float currentHp)
    {
        _playerCurrentHp = currentHp;
        if (currentHp <= 50 && currentHp > 25)
        {
            ActiveIcon(0);
        }
        else if (currentHp <= 25 && currentHp > 5)
        {
            ActiveIcon(1);
        }
        else if (currentHp <= 5)
        {
            ActiveIcon(2);
        }
    }

    public void RefreshOverheatPlayer(float currentOverheat)
    {
        _playerCurrentOverheat = currentOverheat;      
    }

    private void ActiveIcon(int number)
    {
        foreach (var item in damageIcons)
        {
            item.SetActive(false);
        }
        damageIcons[number].SetActive(true);
    }

}
