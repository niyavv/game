using System;
using System.Collections;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

namespace Enemy
{
    public class EnemyHideController : MonoBehaviour
    {
        [SerializeField] private float _hideDistance;
        [SerializeField] private float _trackingDistance;
        [SerializeField] private float _slowdownMultiplier;
        [SerializeField] private float _speedUpMultiplier;
        [SerializeField] private float _trackingWaitTime;
        [SerializeField] private Move _move;
        [SerializeField] private Transform _trackingTarget;

        private IEnumerator _slowDownCoroutine;
        private TrackingState _trackingState;
        private void Awake()
        {
            Events.HealthCountChangedEvent += OnPlayerReceivedDamage;
        }

        private void OnDestroy()
        {
            Events.HealthCountChangedEvent -= OnPlayerReceivedDamage;
        }

        private void Update()
        {
            var posWithoutY = new Vector2(transform.position.x, 0);
            var targetPosWithoutY = new Vector2(_trackingTarget.position.x, 0);
            var distance = Vector2.Distance(posWithoutY, targetPosWithoutY);
            if (_trackingState == TrackingState.Tracking)
            {
                _move.SetSpeedMultiplier(distance > _trackingDistance ? _speedUpMultiplier : 1);
            }
            else if (_trackingState == TrackingState.Hidden)
            {
                _move.SetSpeedMultiplier(distance < _hideDistance ? _slowdownMultiplier : 1);
            }
        }

        private void OnPlayerReceivedDamage(HealthData obj)
        {
            if (_slowDownCoroutine != null)
            {
                StopCoroutine(_slowDownCoroutine);
            }
            _slowDownCoroutine = StopTracking();
            StartCoroutine(_slowDownCoroutine);

            _trackingState = TrackingState.Tracking;
        }

        private IEnumerator StopTracking()
        {
            yield return new WaitForSeconds(_trackingWaitTime);
            _trackingState = TrackingState.Hidden;

        }

        public enum TrackingState
        {
            Unknown,
            Tracking,
            Hidden
        }
        
    }
}