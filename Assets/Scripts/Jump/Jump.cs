using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] private GameObject _boosterFxParent;
        public Rigidbody2D rb2D;
        public float velocity = 1f;

        private bool isJumping;
        private int _maxJumpAmount = 1;
        private int jumpAmount;

        private BoosterHandler _boosterHandler;
        private void Awake()
        {
            Events.BoosterReceivedEvent += OnBoosterReceived;
        }

        private void OnDestroy()
        {
            Events.BoosterReceivedEvent -= OnBoosterReceived;
            _boosterHandler?.Dispose();
        }

        private void OnBoosterReceived(BoosterData obj)
        {
            if (obj.BoosterType == BoosterType.DoubleJump)
            {
                _boosterHandler?.Dispose();
                _boosterHandler = new BoosterHandler(obj.Duration);
                _maxJumpAmount = 2;
                jumpAmount++;
                _boosterHandler.StartBooster(OnBoosterCompleted);
                _boosterFxParent.SetActive(true);
                Debug.Log("Double jump booster received");
            }
        }

        private void OnBoosterCompleted()
        {
            _maxJumpAmount = 1;
            if (jumpAmount > 1)
            {
                jumpAmount = 1;
            }
            _boosterFxParent.SetActive(false);

            Debug.Log("Double jump booster finished");

        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
               TryJump();
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IJumpable jumpable))
            {
                ResetJump();
            }
        }
        
        

        private void TryJump()
        {
            if (jumpAmount > 0)
            {
                jumpAmount--;
                rb2D.velocity = new Vector2(rb2D.velocity.x, velocity);
            }
        }

        private void ResetJump()
        {
            jumpAmount = _maxJumpAmount;
        }
    }
}