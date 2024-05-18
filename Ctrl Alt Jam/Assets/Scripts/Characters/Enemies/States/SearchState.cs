using JAM.Characters;
using UnityEngine;

namespace JAM.Boss
{
    public class SearchState : IBossState
    {
        private BossState _state = BossState.Search;
        public BossState State { get { return _state; } }

        private BossBehavior _boss;
        private float _detectionRadius;

        private Collider2D [] _colliderDetected;
        private LayerMask _detectionLayer;
        private bool _hasDetectecTarget;
        private int _count;

        public SearchState(BossBehavior boss, BossFuriaData data)
        {
            _boss = boss;
            _detectionRadius = data.detectionRadius;
            _detectionLayer = data.detectionLayer;

            _colliderDetected = new Collider2D[1];
        }

        public void EnterState()
        {
            Debug.Log("Enter Search State");

            _boss.animator.SetBool("isFlying", true);
            _hasDetectecTarget = false;         
        }

        public void HandleState()
        {

        }

        public void HandleStateInLoop()
        {
            if (!_hasDetectecTarget)
            {
                Debug.Log("Searching...");
                _count = Physics2D.OverlapCircleNonAlloc(_boss.transform.position, _detectionRadius, _colliderDetected, _detectionLayer);
                if (_count > 0)
                {
                    Debug.Log("has Detectecd Target");
                    _hasDetectecTarget = true;

                    GameObject target = _colliderDetected[0].gameObject;
                    _boss.BossTarget = target;
                    _boss.animator.SetBool("isFlying", false);
                    _boss.OnChangeState(BossState.Chasing);
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
