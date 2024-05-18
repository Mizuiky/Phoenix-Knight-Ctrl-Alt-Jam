
namespace JAM.Boss
{
    public class DeadState : IState
    {
        private BossState _state = BossState.Dead;
        public BossState State { get { return _state; } }

        public void EnterState()
        {

        }

        public void HandleState()
        {

        }

        public void HandleStateInLoop()
        {

        }
       
        public void StatePhysicsUpdate()
        {

        }

        public void ExitState()
        {

        }
    }
}