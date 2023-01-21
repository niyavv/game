using System;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace.Health
{
    public class InvincibilityViewController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _blinkRate = 0.35f;
        private Tween _blinkTween;
        private void Awake()
        {
            Events.InvincibilityStateChangedEvent += OnInvincilibityStateChanged;

        }

        private void OnDestroy()
        {
            Events.InvincibilityStateChangedEvent -= OnInvincilibityStateChanged;
            
        }

        private void OnInvincilibityStateChanged(InvincibilityStateData obj)
        {
            if (obj.IsEnabled)
            {
                _blinkTween.KillTween();
                _blinkTween = _spriteRenderer.DOFade(0, _blinkRate).From(1).SetLoops(-1, LoopType.Yoyo);
            }
            else
            {
                var color = _spriteRenderer.color;
                color = new Color(color.r, color.g,
                    color.b, 1);
                _spriteRenderer.color = color;
                _blinkTween.KillTween();
            }
        }
       
        
    }
}