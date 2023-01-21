using DefaultNamespace.Health;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "HealthSettings", menuName = "HealthSettings", order = 0)]
    public class HealthSettings : ScriptableObject
    {
        public int HealthCount;
        public bool IsInvincible;
        public HealthUIView HealthUIViewPrefab;
    }
}