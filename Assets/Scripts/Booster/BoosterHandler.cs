using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class BoosterHandler : IDisposable
    {
        private float _duration;
        private CoroutineRunner _coroutineRunner;
        private Action _onBoosterCompleted;
        private IEnumerator _coroutine;
        private bool _isBoosterRunning;
        public BoosterHandler(float duration)
        {
            _coroutineRunner = CoroutineRunner.Instance;
            _duration = duration;
        }
        
        public void StartBooster(Action onBoosterCompleted)
        {
            _onBoosterCompleted = onBoosterCompleted;
            if (_coroutine != null)
            {
                _coroutineRunner.StopCoroutine(_coroutine);
            }
            _coroutine = WaitForBooster();
            _coroutineRunner.StartCoroutine(_coroutine);
            _isBoosterRunning = true;
        }

        public bool IsBoosterActive()
        {
            return _isBoosterRunning;
        }

        private IEnumerator WaitForBooster()
        {
            yield return new WaitForSeconds(_duration);
            _isBoosterRunning = false;
            _onBoosterCompleted?.Invoke();
        }

        public void Dispose()
        {
            if (_coroutine != null && _coroutineRunner != null)
            {
                _coroutineRunner.StopCoroutine(_coroutine);
            }
        }
    }
}