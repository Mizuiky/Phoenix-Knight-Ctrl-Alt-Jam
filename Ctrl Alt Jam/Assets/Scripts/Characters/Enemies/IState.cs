
using JAM.Abilites;

namespace JAM.StateMachine
{
    public interface IState
    {
        public AbiliteState State { get; }

        public void ResetState();
        public void EnterState();
        public void HandleStateInLoop();
        public void HandleState();
        public void StatePhysicsUpdate();
        public void ExitState();
    }
}

