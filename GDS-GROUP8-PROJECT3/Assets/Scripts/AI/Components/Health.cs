﻿using UnityEngine;

namespace BehaviorDesigner.Runtime.Tactical
{
    /// <summary>
    /// Example component which adds health to an object.
    /// </summary>
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private BasicData basicData;
        // The amount of health to begin with
        [Header("!Only For Player!")]
        [SerializeField] private HudManager hudManager;
        [HideInInspector]public float currentHealth;

        /// <summary>
        /// Initailzies the current health.
        /// </summary>
        private void Awake()
        {
            currentHealth = basicData.health;
        }

        /// <summary>
        /// Take damage. Deactivate if the amount of remaining health is 0.
        /// </summary>
        /// <param name="amount"></param>
        public void Damage(float amount)
        {
            currentHealth = Mathf.Max(currentHealth - amount, 0);

            if (hudManager != null)
            {
                hudManager.RefreshHpPlayer(amount, false);
            }

            if (currentHealth == 0) {
                gameObject.SetActive(false);
            }
        }

        // Is the object alive?
        public bool IsAlive()
        {
            return currentHealth > 0;
        }
        public void RegenHp(int hpToRegen)
        {
            currentHealth += hpToRegen;
            if (currentHealth >basicData.health)
            {
                currentHealth = basicData.health;
            }
            hudManager.RefreshHpPlayer(hpToRegen, true);
        }

        /// <summary>
        /// Sets the current health to the starting health and enables the object.
        /// </summary>
        public void ResetHealth()
        {
            currentHealth = basicData.health;
            gameObject.SetActive(true);
        }
    }
}