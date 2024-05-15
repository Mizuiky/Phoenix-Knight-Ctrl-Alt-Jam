
namespace JAM.Abilites
{
    public interface IPlayerAbility
    {
        public void SetInput(PlayerInputActions actions);
        public void Enter();
        public void HandleInput();
        public void HandleAbility();
        public void PhysicsUpdate();
        public void Exit();
    }
}
