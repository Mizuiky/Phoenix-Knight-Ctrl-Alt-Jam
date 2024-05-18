using UnityEngine;

namespace JAM.Boss
{
    public class DeadState : IBossState
    {
        private BossState _state = BossState.Dead;
        public BossState State { get { return _state; } }

        private BossBehavior _boss;

        public DeadState(BossBehavior boss, BossFuriaData data)
        {
            _boss = boss;
        }

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