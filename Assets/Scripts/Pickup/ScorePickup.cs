using UnityEngine;

namespace DefaultNamespace
{
    public class ScorePickup : MonoBehaviour, IPickable
    {
        [SerializeField] private int _addScoreAmount;
        public void OnPickedUp()
        {
            Events.ScoreIncreasedEvent?.Invoke(new ScoreData(_addScoreAmount));
            Destroy(gameObject);
        }
    }
}