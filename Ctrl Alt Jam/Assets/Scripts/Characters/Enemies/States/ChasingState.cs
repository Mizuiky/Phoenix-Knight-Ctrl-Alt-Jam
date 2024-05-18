using UnityEngine;
using JAM.Characters;

namespace JAM.Boss
{
    public class ChasingState : IState
    {
        private BossState _state = BossState.Chasing;
        public BossState State { get { return _state; } }

        private CharacterBase _target;
        private BossBehavior _boss;

        private Vector3 _currentPosition;

        private float _minDistanceToAttack;

        private bool isChasing;
        private bool _targetIsDamageable = false;

        public void EnterState()
        {
            isChasing = true;
        }

        public void HandleState()
        {

        }

        public void HandleStateInLoop()
        {
            if(Vector3.Distance(_boss.transform.position, _target.transform.position) < _minDistanceToAttack && isChasing)
            {
                isChasing = false;
                _boss.OnChangeState(BossState.Dash);
            }

            StatePhysicsUpdate();
        }

        public void StatePhysicsUpdate()
        {
            //_boss.characterComponents.movement
        }

        public void ExitState()
        {

        }

    }
}