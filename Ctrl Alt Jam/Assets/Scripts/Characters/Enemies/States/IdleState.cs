using UnityEngine;

namespace JAM.Boss
{
    public class IdleState : IBossState
    {
        private BossState _state = BossState.Idle;
        public BossState State { get { return _state; } }

        private BossBehavior _boss;

        private AnimatorStateInfo _currentAnimation;

        private float _timeToNextState;
        private float _passedTime;

        public IdleState(BossBehavior boss, BossFuriaData data)
        {           
            _boss = boss;
            _timeToNextState = data.timeToNextState;
            _passedTime = _timeToNextState;
        }

        public void EnterState()
        {
            //_currentAnimation = _boss.animator.GetCurrentAnimatorStateInfo(0);

            //if (!_currentAnimation.IsName("Idle"))
            //    _boss.SetAnimation("Idle");

            _passedTime = 0;
        }
   
        public void HandleState()
        {
            
        }

        public void HandleStateInLoop()
        {
            if(_passedTime < _timeToNextState)
            {
                _passedTime += Time.deltaTime;
                Debug.Log("waiting idle finish");
                if (_passedTime > _timeToNextState)
                {
                    Debug.Log("idle finished");
                    _boss.OnChangeState(BossState.Search);
                }                    
            }
        }

        public void StatePhysicsUpdate()
        {
            
        }
        public void ExitState()
        {

        }
    }
}

