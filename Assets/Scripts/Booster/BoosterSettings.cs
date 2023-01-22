using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "BoosterSettings", menuName = "BoosterSettings", order = 0)]
    public class BoosterSettings : ScriptableObject
    {
        public BoosterType BoosterType;
        public float Duration;
    }
}