using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PickupController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IPickable pickable))
            {
                pickable.OnPickedUp();
            }
        }
    }
}