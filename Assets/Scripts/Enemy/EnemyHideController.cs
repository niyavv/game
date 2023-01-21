using System;
using System.Collections;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

namespace Enemy
{
    public class EnemyHideController : MonoBehaviour
    {
        [SerializeField] private float _hideDelay;
        [SerializeField] private float _hideDuration;
        [SerializeField] private float _showDuration;
        [SerializeField] private Ease _hideEase;
        [SerializeField] private Transform _hidePosition;
        [SerializeField] private Transform _showPosition;

        private Tween _showHideTween;
        private IEnumerator _hideWaitCoroutine;
        private bool _isVisible = true;
        private void Awake()
        {
            Events.HealthCountChangedEvent += OnPlayerReceivedDamage;
        }

        private void OnDestroy()
        {
            Events.HealthCountChangedEvent -= OnPlayerReceivedDamage;
            
        }
        private void OnPlayerReceivedDamage(HealthData obj)
        {
            if (!_isVisible)
            {
                Show();
                StartCoroutine(LateDo(Hide, _showDuration));
            }
        }

        private void Start()
        {
            StartCoroutine(LateDo(Hide, _hideDelay));
        }

        private IEnumerator LateDo(Action action, float hideDelay)
        {
            yield return new WaitForSeconds(hideDelay);
            action?.Invoke();
        }

        public void Hide()
        {
            transform.DOMoveX(_hidePosition.position.x, _hideDuration).SetEase(_hideEase).OnComplete(() => _isVisible = false);
        }

        public void Show()
        {
            _isVisible = true;
            transform.DOMoveX(_showPosition.position.x, _hideDuration).SetEase(_hideEase);
        }
    }
}