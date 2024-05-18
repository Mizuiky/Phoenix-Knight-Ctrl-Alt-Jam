using System;

namespace JAM.Health
{
    public interface IHealth
    {
        public event Action OnKill;
        public void Init();
        public void Reset();
        public void OnDamage(float damage);
    }
}