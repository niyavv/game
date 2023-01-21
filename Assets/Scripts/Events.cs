using System;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Events
    {
        // public static Action
        public static Action<HealthData> HealthCountChangedEvent;
        public static Action<DamageData> PlayerReceivedDamageEvent;
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
}