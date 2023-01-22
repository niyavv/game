using UnityEngine;

namespace DefaultNamespace
{
    public class BoosterPickup : MonoBehaviour, IPickable
    {
        [SerializeField] private BoosterSettings _boosterSettings;
        public void OnPickedUp()
        {
            Events.BoosterReceivedEvent?.Invoke(new BoosterData(_boosterSettings.BoosterType, _boosterSettings.Duration));
            Destroy(gameObject);
        }
    }
}