using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Jump : MonoBehaviour
    {
        public Rigidbody2D rb2D;
        public float velocity = 1f;

        private bool isJumping;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !isJumping)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, velocity);
                isJumping = true;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IJumpable jumpable))
            {
                isJumping = false;
            }
        }
    }
}