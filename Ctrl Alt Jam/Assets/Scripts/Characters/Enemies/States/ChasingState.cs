using UnityEngine;
using JAM.Characters;

namespace JAM.Boss
{
    public class ChasingState : IBossState
    {
        private BossState _state = BossState.Chasing;
        public BossState State { get { return _state; } }

        private BossBehavior _boss;

        private float _minDistanceToAttack;

        private bool _isChasing;
        private bool _targetIsDamageable = false;  
        
        private float _timeToStartChasing;
        private float _passedStartChasingTime;

        private Vector3 _direction;
        private Vector3 _currentPosition;

        public ChasingState(BossBehavior boss, BossFuriaData data)
        {
            _boss = boss;
            _minDistanceToAttack = data.minDistanceToAttack;
            _timeToStartChasing = data.timeToStartChasing;
        }

        public void EnterState()
        {
            Debug.Log("Enter chasing state");
            _isChasing = false;
            _passedStartChasingTime = 0;
        }

        public void HandleState()
        {

        }

        public void HandleStateInLoop()
        {
            if (_isChasing)
            {
                if (Vector3.Distance(_boss.transform.position, _boss.BossTarget.transform.position) < _minDistanceToAttack)
                {
                    Debug.Log("stop chasing");
                    _isChasing = false;
                    _boss.animator.SetBool("isFlying", false);
                    _boss.OnChangeState(BossState.Dash);
                }
            }
        }

        public void StatePhysicsUpdate()
        {
            if (!_isChasing)
            {
                if (_passedStartChasingTime < _timeToStartChasing)
                {
                    Debug.Log("Waiting to start chasing target");
                    _passedStartChasingTime += Time.deltaTime;
                    if (_passedStartChasingTime > _timeToStartChasing)
                    {
                        _isChasing = true;
                        _boss.animator.SetBool("isFlying", true);
                    }                      
                }
            }

            if (_isChasing)
            {
                Debug.Log("chasing player");
                _direction = _boss.BossTarget.transform.position - _boss.transform.position;
                _direction.Normalize();

                _boss.movement.Movementinput = new Vector2(_direction.x, _direction.y);
            }            
        }

        public void ExitState()
        {

        }
    }
}