using UnityEngine;
using JAM.Characters;

namespace JAM.Abilites
{
    public abstract class EnemyAbilityBase<T> : MonoBehaviour, IEnemyAbility
    {
        private string abilityName = typeof(T).Name.Replace("Ability", "");
        [SerializeField] protected AbiliteState state = AbiliteState.Ready;

        protected CharacterBase character;

        private void Awake()
        {
            character = GetComponentInParent<CharacterBase>();
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void PhysicsUpdate() { }
        public virtual void HandleAbility() { }
        public virtual void HandleInput() { }
    }
}