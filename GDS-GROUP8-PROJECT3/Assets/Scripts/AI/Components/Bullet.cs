using UnityEngine;

namespace BehaviorDesigner.Runtime.Tactical
{
    public class Bullet : MonoBehaviour
    {

        [SerializeField] private EnemyBullet enemyBullet;

        private void Awake()
        {
            Invoke("SelfDestruct", enemyBullet.selfDestructTime);
        }

        private void OnParticleCollision(GameObject other)
        {
            IDamageable damageable;
            if ((damageable = other.gameObject.GetComponent(typeof(IDamageable)) as IDamageable) != null)
            {
                damageable.Damage(enemyBullet.damage);
                Destroy(gameObject);
            }
        }

        private void SelfDestruct()
        {
            Destroy(gameObject);
        }
    }
}