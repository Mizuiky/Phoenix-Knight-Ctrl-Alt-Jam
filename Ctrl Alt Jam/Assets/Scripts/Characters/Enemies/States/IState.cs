

namespace JAM.Boss
{
    public interface IState
    {
        public BossState State { get; }

        public void EnterState();
        public void HandleStateInLoop();
        public void HandleState();
        public void StatePhysicsUpdate();
        public void ExitState();
    }
}

