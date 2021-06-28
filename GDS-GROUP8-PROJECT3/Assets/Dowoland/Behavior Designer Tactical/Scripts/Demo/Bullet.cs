using UnityEngine;

namespace BehaviorDesigner.Runtime.Tactical
{
    public class Bullet : MonoBehaviour
    {

        [SerializeField] private EnemyBullet enemyBullet;

        [SerializeField] private Rigidbody m_Rigidbody;
        [SerializeField] private Transform m_Transform;

        /// <summary>
        /// Cache the component references and initialize the default values.
        /// </summary>
        private void Awake()
        {
            Invoke("SelfDestruct", enemyBullet.selfDestructTime);
        }

        /// <summary>
        /// Move in the forward direction.
        /// </summary>
        void Update()
        {
            m_Rigidbody.MovePosition(m_Rigidbody.position + enemyBullet.speed * m_Transform.forward * Time.deltaTime);
        }

        /// <summary>
        /// Perform any damage to the collided object and destroy itself.
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                IDamageable damageable;
                if ((damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable) != null)
                {
                    damageable.Damage(enemyBullet.damage);
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