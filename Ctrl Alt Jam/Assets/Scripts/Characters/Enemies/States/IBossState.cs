

namespace JAM.Boss
{
    public interface IBossState
    {
        public BossState State { get; }

        public void EnterState();
        public void HandleStateInLoop();
        public void HandleState();
        public void StatePhysicsUpdate();
        public void ExitState();
    }
}

