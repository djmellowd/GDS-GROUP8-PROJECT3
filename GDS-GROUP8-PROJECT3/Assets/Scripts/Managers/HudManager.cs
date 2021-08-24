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
    [SerializeField]
    private Image crossHair;

    [Header("Player HP")]
    [SerializeField]
    private Slider hpSlider;
    [SerializeField]
    private Image hpImage;
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
        if (_playerCurrentOverheat != overheatSlider.value)
        {
            overheatSlider.value = Mathf.MoveTowards(overheatSlider.value, _playerCurrentOverheat, barsSpeed * Time.deltaTime);
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
        overheatSlider.value = 0;
    }

    public void ChangeColorCrosshair()
    {
     StartCoroutine(ChangeColor());
    }

   private IEnumerator ChangeColor()
    {
        crossHair.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        crossHair.color = Color.white;
    }

    public void RefreshHpPlayer(float value, bool isHeal)
    {
        float percentDmg = 0;
        if (!isHeal)
        {
            _playerCurrentHp -= value;
        }
        else
        {
            _playerCurrentHp += value;
        }

        if (_playerCurrentHp <= 50 && _playerCurrentHp > 25)
        {
            ActiveIcon(0);
            hpImage.color = Color.green;
        }
        else if (_playerCurrentHp <= 25 && _playerCurrentHp > 5)
        {
            ActiveIcon(1);
            hpImage.color = Color.yellow;
        }
        else if (_playerCurrentHp <= 5)
        {
            hpImage.color = Color.red;
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
