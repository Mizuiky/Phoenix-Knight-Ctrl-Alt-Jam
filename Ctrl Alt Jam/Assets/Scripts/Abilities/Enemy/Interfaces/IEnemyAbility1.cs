
namespace JAM.Abilites
{
    public interface IEnemyAbility
    {
        void Enter();
        void HandleInput();
        void HandleAbility();
        void PhysicsUpdate();
        void Exit();
    }
}

