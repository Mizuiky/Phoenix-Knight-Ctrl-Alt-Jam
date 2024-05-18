using UnityEngine;
using JAM.Characters;
using System;
using UnityEngine.InputSystem;

namespace JAM.Abilites
{
    public enum AbiliteState
    {
        Ready,
        Active,
        Cooldown
    }

    public enum AbilityType
    {
        LightUp,
        Fireball,
        Interact,
        None
    }

    public abstract class PlayerAbilityBase<T> : MonoBehaviour, IPlayerAbility
    {
        [SerializeField] protected AbiliteState _state = AbiliteState.Ready;
       
        private string _abilityName = typeof(T).Name.Replace("Ability", "");
   
        protected PlayerInputActions _playerInputActions;
        protected CharacterBase _character;

        protected AbilityType _abilityType;
        public AbilityType Type { get { return _abilityType; } }
        public AbiliteState State { get { return _state; } set { _state = value; } }

        public event Action<AbilityType> OnActivateAbility;
       
        private void Awake()
        {
            _character = GetComponentInParent<CharacterBase>();
        }

        public void SetInput(PlayerInputActions actions)
        {
            _playerInputActions = actions;
        }

        protected virtual void ActivateAbility(InputAction.CallbackContext value)
        {
            if (_state == AbiliteState.Ready)
            {
                _state = AbiliteState.Active;
                OnActivateAbility?.Invoke(_abilityType);
                Debug.Log("Activate ability" + _abilityName);
            }
            else
            {
                _state = AbiliteState.Ready;
                Debug.Log("Deactivate ability" + _abilityName);
            }
                
            //update ui conforme for ready ou active
        }

        public virtual void ResetAbility()
        {
            _state = AbiliteState.Ready;
            Debug.Log("reset ability" + _abilityName);
            //update ui
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void PhysicsUpdate() { }
        public virtual void HandleAbilityInLoop() { }
        public virtual void HandleAbility() { }
        public virtual void HandleInput() { }
    }
}