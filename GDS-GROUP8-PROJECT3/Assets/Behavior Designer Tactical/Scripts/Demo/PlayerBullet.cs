using UnityEngine;

namespace BehaviorDesigner.Runtime.Tactical
{
    public class PlayerBullet : MonoBehaviour
    {

        [SerializeField] private EnemyBullet enemyBullet1;

        [SerializeField] private Camera playerCamera;

        [SerializeField] private Rigidbody m_Rigidbody1;
        [SerializeField] private Transform m_Transform1;

        /// <summary>
        /// Cache the component references and initialize the default values.
        /// </summary>
        private void Awake()
        {
            // Invoke("SelfDestruct", enemyBullet1.selfDestructTime);
        }

        /// <summary>
        /// Move in the forward direction.
        /// </summary>
        void Update()
        {
            m_Rigidbody1.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
            m_Rigidbody1.transform.forward = playerCamera.transform.forward;
        }

        /// <summary>
        /// Perform any damage to the collided object and destroy itself.
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                IDamageable damageable;
                if ((damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable) != null)
                {
                    damageable.Damage(enemyBullet1.damage);
                    Destroy(gameObject);
                }
            }
        }

        /// <summary>
        /// Destroy itself.
        /// </summary>
        private void SelfDestruct()
        {
            Destroy(gameObject);
        }
    }
}
