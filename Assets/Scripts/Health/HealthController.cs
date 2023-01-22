using System;
using System.Collections;
using ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace.Health
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _boxCollider;
        [SerializeField] private HealthSettings _healthSettings;
        private int _currentHealthCount;
        private bool _isInvincible;
        private void Awake()
        {
            _currentHealthCount = _healthSettings.HealthCount;
        }


        private void OnTriggerEnter2D(Collider2D collision)//i�inden ge�mesi gerek
        {
            if(collision.gameObject.CompareTag("DeathArea") && !_isInvincible)
            {
                GetDamage(1);
                Destroy(collision.gameObject);
            }
        }

        private void GetDamage(int damage)
        {
            if (_healthSettings.IsInvincible)
            {
                Debug.Log("No damage taken because player is invincible.");
                return;
            }
            _currentHealthCount = Mathf.Clamp(_currentHealthCount-damage, 0, Int32.MaxValue);
            Events.HealthCountChangedEvent?.Invoke(new HealthData(_currentHealthCount));
            if (_currentHealthCount <= 0)
            {
                Debug.Log("Dead");
            }
            else
            {
                ActivateTemporaryInvincibility();
            }
        }

        private void ActivateTemporaryInvincibility()
        {
            _isInvincible = true;
            Events.InvincibilityStateChangedEvent?.Invoke(new InvincibilityStateData(true,
                _healthSettings.TemporaryInvincibilityDuration));
            StartCoroutine(DisableInvincibility());
        }

        private IEnumerator DisableInvincibility()
        {
            yield return new WaitForSeconds(_healthSettings.TemporaryInvincibilityDuration);
            Events.InvincibilityStateChangedEvent?.Invoke(new InvincibilityStateData(false,
                _healthSettings.TemporaryInvincibilityDuration));
            _isInvincible = false;
        }
    }
}