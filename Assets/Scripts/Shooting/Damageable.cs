using UnityEngine;

namespace Shooting
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        [SerializeField] private DamageEffect _damageEffect;
        [SerializeField] private int Health;
        public void Damage(int damage)
        {
            Health -= damage;
            if (_damageEffect != null)
            {
                _damageEffect.Play();
            }
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}