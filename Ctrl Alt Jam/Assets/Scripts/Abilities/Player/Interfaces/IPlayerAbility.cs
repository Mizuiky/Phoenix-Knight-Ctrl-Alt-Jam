using System;

namespace JAM.Abilites
{
    public interface IPlayerAbility
    {
        public event Action<AbilityType> OnActivateAbility;
        public AbilityType Type { get; }
        public AbiliteState State { get; }

        public void ResetAbility();
        public void SetInput(PlayerInputActions actions);
        public void Enter();
        public void HandleInput();
        public void HandleAbilityInLoop();
        public void HandleAbility();
        public void PhysicsUpdate();
        public void Exit();
    }
}
