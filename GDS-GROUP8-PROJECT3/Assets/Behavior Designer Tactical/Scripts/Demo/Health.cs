using UnityEngine;

namespace BehaviorDesigner.Runtime.Tactical
{
    /// <summary>
    /// Example component which adds health to an object.
    /// </summary>
    public class Health : MonoBehaviour, IDamageable
    {
        // The amount of health to begin with
        [Header("Ogolne")]
        [SerializeField] private BasicData basicData;
        [Header("Tylko dla gracza")]
        [SerializeField] private PlayerMovement playerMovement;

        private float _currentHealth;

        /// <summary>
        /// Initailzies the current health.
        /// </summary>
        private void Awake()
        {
            _currentHealth = basicData.health;
        }

        /// <summary>
        /// Take damage. Deactivate if the amount of remaining health is 0.
        /// </summary>
        /// <param name="amount"></param>
        public void Damage(float amount)
        {
            _currentHealth = Mathf.Max(_currentHealth - amount, 0);
            if (_currentHealth == 0) 
            {
                if (gameObject.tag=="Player")
                {
                    playerMovement.Die();
                }
                else
                {
                    gameObject.SetActive(false); 
                }
            }
        }

        // Is the object alive?
        public bool IsAlive()
        {
            return _currentHealth > 0;
        }

        /// <summary>
        /// Sets the current health to the starting health and enables the object.
        /// </summary>
        public void ResetHealth()
        {
            _currentHealth = basicData.health;
            gameObject.SetActive(true);
        }
    }
}