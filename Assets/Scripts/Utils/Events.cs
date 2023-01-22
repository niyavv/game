using System;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Events
    {
        // public static Action
        public static Action<HealthData> HealthCountChangedEvent;
        public static Action<InvincibilityStateData> InvincibilityStateChangedEvent;
        public static Action<BoosterData> BoosterReceivedEvent;
        public static Action<ScoreData> ScoreIncreasedEvent;
    }

    public struct HealthData
    {
        public int CurrentHealth;

        public HealthData(int currentHealth)
        {
            CurrentHealth = currentHealth;
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

    public struct BoosterData
    {
        public BoosterType BoosterType;
        public float Duration;
        public BoosterData(BoosterType boosterType, float duration)
        {
            BoosterType = boosterType;
            Duration = duration;
        }
    }

    public enum BoosterType
    {
        Unknown,
        DoubleJump
    }

    public struct ScoreData
    {
        public int scoreToAdd;

        public ScoreData(int scoreToAdd)
        {
            this.scoreToAdd = scoreToAdd;
        }
    }
}