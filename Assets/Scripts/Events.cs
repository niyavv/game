using System;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Events
    {
        // public static Action
        public static Action<HealthData> HealthCountChangedEvent;
        public static Action<DamageData> PlayerReceivedDamageEvent;
        public static Action<InvincibilityStateData> InvincibilityStateChangedEvent;
    }

    public struct HealthData
    {
        public int CurrentHealth;

        public HealthData(int currentHealth)
        {
            CurrentHealth = currentHealth;
        }
    }

    public struct DamageData
    {
        public GameObject Damager;
        public int DamageAmount;

        public DamageData(GameObject damager)
        {
            DamageAmount = 1;
            this.Damager = damager;
        }
    }
    public struct InvincibilityStateData
    {
        public bool IsEnabled;
        public float Duration;

        public InvincibilityStateData(bool isEnabled, float duration)
        {
            IsEnabled = isEnabled;
            Duration = duration;
        }
    }
}