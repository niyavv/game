using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;

namespace Shooting
{
    public class Bullet : MonoBehaviour
    {
        private int _damage;
        private float _destroyDuration;
        private CoroutineHandler _coroutineHandler;
        public void Init(int damage, float destroyDuration)
        {
            _damage = damage;
            _destroyDuration = destroyDuration;
            _coroutineHandler = new CoroutineHandler();
            _coroutineHandler.Start(DestroyCountdown());
        }
       
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(_damage);
                DestroyBullet();
            }
        }

        private IEnumerator DestroyCountdown()
        {
            yield return new WaitForSeconds(_destroyDuration);
            DestroyBullet();
        }

        private void DestroyBullet()
        {
            _coroutineHandler.Dispose();
            Destroy(gameObject);
        }
    }
}