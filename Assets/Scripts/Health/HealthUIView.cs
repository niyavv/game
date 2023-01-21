using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Health
{
    public class HealthUIView : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;

        public void ShowHealthView()
        {
        }

        public void DestroyHealthView()
        {
            Destroy(gameObject);
        }
    }
}