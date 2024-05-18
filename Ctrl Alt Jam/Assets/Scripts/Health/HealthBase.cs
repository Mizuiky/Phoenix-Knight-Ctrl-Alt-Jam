using JAM.UI;
using System;
using UnityEngine;

namespace JAM.Health
{
    public class HealthBase : MonoBehaviour, IHealth
    {
        [SerializeField] private float _maxLife;
        [SerializeField] private SliderUpdater _sliderUpdater;

        private float _currentlife;
        public event Action OnKill;

        public virtual void Init()
        {         
            _currentlife = _maxLife;
            _sliderUpdater.Init(_maxLife);
        }

        public virtual void Reset()
        {
            _currentlife = _maxLife;
            UpdateUI();
        }

        public void OnDamage(float damage)
        {
            _currentlife -= damage;

            if (_currentlife <= 0)
            {
                _currentlife = 0;
                OnKill?.Invoke();
            }
                
            UpdateUI();
        }

        public virtual void OnHealing()
        {
            _currentlife = _maxLife;
            UpdateUI();
        }

        private void UpdateUI()
        {
            if(_currentlife >= 0)
                _sliderUpdater.UpdateSlider(_currentlife);
        }
    }
}