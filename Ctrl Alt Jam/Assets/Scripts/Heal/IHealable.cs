using System;

namespace JAM.Heal
{
    public interface IHealable
    {
        public event Action OnKill;
        public void Init();
        public void Reset();
        public void OnDamage(float damage);
    }
}