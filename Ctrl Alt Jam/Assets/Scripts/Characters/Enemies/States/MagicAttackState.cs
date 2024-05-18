using UnityEngine;

namespace JAM.Boss
{
    public class MagicAttackState : MonoBehaviour, IState
    {
        private BossState _state = BossState.MagicAttack;
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