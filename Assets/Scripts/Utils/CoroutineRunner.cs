using UnityEngine;

namespace DefaultNamespace
{
    public class CoroutineRunner : MonoBehaviour
    {
        private static CoroutineRunner _instance;

        public static CoroutineRunner Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                _instance = FindObjectOfType<CoroutineRunner>();
                if (_instance == null)
                {
                    var go = new GameObject("CoroutineRunner", typeof(CoroutineRunner));
                    _instance = go.GetComponent<CoroutineRunner>();
                }
                return _instance;
            }
        }
    }
}