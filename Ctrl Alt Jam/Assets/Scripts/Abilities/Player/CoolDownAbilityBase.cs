using JAM.Characters;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JAM.Abilites
{
    public abstract class CoolDownAbilityBase<T> : MonoBehaviour, IPlayerAbility, ICoolDownAbility
    {
        private string _abilityName = typeof(T).Name.Replace("Ability", "");
        [SerializeField] protected AbiliteState _state = AbiliteState.Ready;

        [SerializeField] private float _cooldowTime;
        [SerializeField] private float _activeTime;

        public float CoolDownTime { get { return _cooldowTime; } }
        public float ActiveTime { get { return _activeTime; } }

        protected AbilityType _abilityType;
        public AbilityType Type { get { return _abilityType; } }
        public AbiliteState State { get { return _state; } }

        protected PlayerInputActions _playerInputActions;
        protected CharacterBase _character;

        public event Action<AbilityType> OnActivateAbility;

        private void Awake()
        {
            _character = GetComponent<CharacterBase>();
            _character = GetComponentInParent<CharacterBase>();
        }

        public void SetInput(PlayerInputActions actions)
        {
            _playerInputActions = actions;
        }

        protected void ChangeAbilityState(InputAction.CallbackContext value)
        {
            if (_state == AbiliteState.Ready)
            {
                _state = AbiliteState.Active;
                OnActivateAbility?.Invoke(_abilityType);
            }
            else
                _state = AbiliteState.Ready;
            //update ui conforme for ready ou active
        }

        public void ResetAbility()
        {
            _state = AbiliteState.Ready;
            //update ui
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void PhysicsUpdate() { }
        public virtual void HandleAbilityInLoop() { }
        public virtual void HandleAbility() { }
        public virtual void HandleInput() { }
        public virtual void InternalInput() { }
        public virtual void ValidateCooldown()
        {
            switch (_state)
            {
                case AbiliteState.Ready:
                    _state = AbiliteState.Active;
                    break;
                case AbiliteState.Active:
                    _state = AbiliteState.Cooldown;
                    break;
                case AbiliteState.Cooldown:
                    if (_cooldowTime >= 0)
                    {
                        _cooldowTime -= Time.deltaTime;
                        return;
                    }
                    _state = AbiliteState.Ready;
                    _cooldowTime = _activeTime;
                    break;
            }
        }
    }
}
