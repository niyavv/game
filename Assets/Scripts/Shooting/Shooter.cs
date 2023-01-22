using System;
using UnityEngine;

namespace Shooting
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private int _bulletDamage;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletPivot;
        [SerializeField] private float _rateOfFire;
        [SerializeField] private float _bulletDestroyTime;

        private float _lastShootTime;
        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) && CanShoot())
            {
                Shoot();
            }
        }

        private bool CanShoot()
        {
            if (Time.time >= _lastShootTime + _rateOfFire)
            {
                _lastShootTime = Time.time;
                return true;
            }

            return false;
        }

        private void Shoot()
        {
            var bullet = Instantiate(_bulletPrefab, _bulletPivot.transform.position, Quaternion.identity);
            bullet.Init(_bulletDamage, _bulletDestroyTime);
        }
    }
}