using UnityEngine;
using JAM.Characters;
using JAM.InputManagement;

namespace JAM.Abilites
{
    public enum AbiliteState
    {
        Ready,
        Active,
        Cooldown
    }

    public abstract class PlayerAbilityBase<T> : MonoBehaviour, IPlayerAbility
    {
        private string abilityName = typeof(T).Name.Replace("Ability", "");
        [SerializeField] protected AbiliteState state = AbiliteState.Ready;

        protected PlayerInputActions _playerInputActions;
        protected CharacterBase character;
        protected InputHandler input;

        private void Awake()
        {
            character = GetComponentInParent<CharacterBase>();
            input = character.characterComponents.input;
        }

        public void SetInput(PlayerInputActions actions)
        {
            _playerInputActions = actions;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void PhysicsUpdate() { }
        public virtual void HandleAbility() { }
        public virtual void HandleInput() { }
    }
}