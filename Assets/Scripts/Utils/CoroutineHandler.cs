using System;
using System.Collections;

namespace DefaultNamespace
{
    public class CoroutineHandler : IDisposable
    {
        private IEnumerator _coroutine;
        private readonly CoroutineRunner _coroutineRunner;
        public CoroutineHandler()
        {
            _coroutineRunner = CoroutineRunner.Instance;
        }

        public void Start(IEnumerator iEnumerator)
        {
           Stop();
           _coroutine = iEnumerator;
           _coroutineRunner.StartCoroutine(_coroutine);
        }

        private void Stop()
        {
            if (_coroutine != null)
            {
                _coroutineRunner.StopCoroutine(_coroutine);
            }
        }

        public void Dispose()
        {
            if (_coroutineRunner != null)
            {
                Stop();
            }
        }
    }
}