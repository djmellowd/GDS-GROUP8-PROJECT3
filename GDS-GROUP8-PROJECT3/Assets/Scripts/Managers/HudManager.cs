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
    }

    public void RefreshOverheatPlayer(float currentOverheat)
    {
        _playerCurrentOverheat = currentOverheat;
    }

}
