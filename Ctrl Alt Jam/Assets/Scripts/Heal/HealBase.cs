using System;
using UnityEngine;

namespace JAM.Heal
{
    public class HealBase : MonoBehaviour, IHealable
    {   
        [SerializeField] float _maxLife;

        private float _currentlife;
        public event Action OnKill;

        public virtual void Init(float startLife)
        {
            _maxLife = startLife;
            Reset();
        }

        public virtual void Reset()
        {
            _currentlife = _maxLife;
            UpdateUI();
        }

        public void OnDamage(float damage)
        {
            if(_currentlife > 0)
                _currentlife -= damage;
            else
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

        }
    }
}