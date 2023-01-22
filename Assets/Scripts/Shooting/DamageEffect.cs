using System;
using DG.Tweening;
using UnityEngine;

namespace Shooting
{
    public class DamageEffect : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private Color _defaultColor;
        [SerializeField] private Color _damageColor;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;

        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        public void Play()
        {
            KillTween();
            _spriteRenderer.DOColor(_defaultColor, _duration).From(_damageColor).SetEase(_ease);
        }

        private void KillTween()
        {
            DOTween.Kill(_spriteRenderer);
        }

        private void OnDestroy()
        {
            KillTween();
        }
    }
}