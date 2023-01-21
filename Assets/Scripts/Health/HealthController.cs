using System;
using ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace.Health
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private HealthSettings _healthSettings;
        private int _currentHealthCount;

        private void Awake()
        {
            _currentHealthCount = _healthSettings.HealthCount;
            Events.PlayerReceivedDamageEvent+= OnPlayerReceivedDamage;
        }

        private void OnDestroy()
        {
            Events.PlayerReceivedDamageEvent-= OnPlayerReceivedDamage;
        }

        private void OnPlayerReceivedDamage(DamageData obj)
        {
            GetDamage(obj.DamageAmount);
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
        }
    }
}