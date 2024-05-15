using JAM.Abilites;
using JAM.Characters;
using JAM.InputManagement;
using UnityEngine;

namespace JAM.Abilites
{
    public abstract class CoolDownAbilityBase<T> : MonoBehaviour, IPlayerAbility, ICoolDownAbility
    {
        private string abilityName = typeof(T).Name.Replace("Ability", "");
        [SerializeField] protected AbiliteState state = AbiliteState.Ready;

        [SerializeField] private float _cooldowTime;
        [SerializeField] private float _activeTime;

        public float CoolDownTime { get { return _cooldowTime; } }
        public float ActiveTime { get { return _activeTime; } }

        protected CharacterBase character;
        protected InputHandler input;

        private void Awake()
        {
            character = GetComponent<CharacterBase>();
            character = GetComponentInParent<CharacterBase>();
            input = character.characterComponents.input;
        }

        public void SetInput(PlayerInputActions actions)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void PhysicsUpdate() { }
        public virtual void HandleAbility() { }
        public virtual void HandleInput() { }
        public virtual void InternalInput() { }
        public virtual void ValidateCooldown()
        {
            switch (state)
            {
                case AbiliteState.Ready:
                    state = AbiliteState.Active;
                    break;
                case AbiliteState.Active:
                    state = AbiliteState.Cooldown;
                    break;
                case AbiliteState.Cooldown:
                    if (_cooldowTime >= 0)
                    {
                        _cooldowTime -= Time.deltaTime;
                        return;
                    }
                    state = AbiliteState.Ready;
                    _cooldowTime = _activeTime;
                    break;
            }
        }
    }
}
