using JAM.Characters;
using UnityEngine;

namespace JAM.Boss
{
    public class DashAttackState : IBossState
    {
        private BossState _state = BossState.Dash;
        public BossState State { get { return _state; } }

        private BossBehavior _boss;
        private float _maxAcceleration;
        private Vector3 _direction;

        public DashAttackState(BossBehavior boss, BossFuriaData data)
        {
            _boss = boss;
            _maxAcceleration = data.maxSpeed;
        }

        public void EnterState()
        {
            Debug.Log("Enter Dash Attack State");
            _boss.animator.SetTrigger("FuriaAttack");
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