using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.Health
{
    public class HealthUIController : MonoBehaviour
    {
        [SerializeField] private HealthSettings _healthSettings;
        [SerializeField] private RectTransform _healthUIViewParent;
        private List<HealthUIView> _healthUIViews = new List<HealthUIView>();
        
        private void Awake()
        {
            Events.HealthCountChangedEvent += OnHealthCountChanged;
            CreateHealthUIView(_healthSettings.HealthCount);
        }
        
        private void OnDestroy()
        {
            Events.HealthCountChangedEvent -= OnHealthCountChanged;
        }
        private void OnHealthCountChanged(HealthData obj)
        {
            TryDestroyHealthUIView();
        }

        private void CreateHealthUIViewAnimated(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var view = CreateHealthUIView();
                view.ShowHealthView();
            }
        }

        private void CreateHealthUIView(int count)
        {
            for (int i = 0; i < count; i++)
            {
                CreateHealthUIView();
            }
        }

        private void TryDestroyHealthUIView()
        {
            if (_healthUIViews.Count > 0)
            {
                var view = _healthUIViews[^1];
                _healthUIViews.Remove(view);
                view.DestroyHealthView();
            }
        }

        private HealthUIView CreateHealthUIView()
        {
            var healthUIView = Instantiate(_healthSettings.HealthUIViewPrefab, _healthUIViewParent, false);
            _healthUIViews.Add(healthUIView);
            return healthUIView;
        }
        
    }
}