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
   [Header("Player HP")]
   [SerializeField] private Slider hpSlider;
   [SerializeField] private TextMeshProUGUI hpValueText;
   [SerializeField][Range(1,10)] private int barSpeed;
   private float _playerCurrentHp;

   [SerializeField] private BasicData playerData;
   
   private void Awake()
   {
      _playerCurrentHp = playerData.health;
      InitializationHealthPanel();
   }
   private void Update()
   {
      if (_playerCurrentHp !=hpSlider.value)
      {
         hpSlider.value = Mathf.MoveTowards(hpSlider.value, _playerCurrentHp, barSpeed * Time.deltaTime);
      }
   }

   private void InitializationHealthPanel()
   {
      hpSlider.maxValue = _playerCurrentHp;
      hpSlider.value = _playerCurrentHp;

      hpValueText.text = _playerCurrentHp.ToString();
   }
   public void RefreshHpPlayer(float currentHp)
   {
      _playerCurrentHp = currentHp;
      hpValueText.text = currentHp.ToString();
   }

  
}
