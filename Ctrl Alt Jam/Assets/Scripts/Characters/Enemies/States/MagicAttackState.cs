using UnityEngine;

namespace JAM.Boss
{
    public class MagicAttackState : IBossState
    {
        private BossState _state = BossState.MagicAttack;
        public BossState State { get { return _state; } }

        private BossBehavior _boss;

        private int _maxProjecteis;
        private float _projectilSpeed;
        private float _projectilLifeTime;

        public MagicAttackState(BossBehavior boss, BossFuriaData data)
        {
            _boss = boss;
            _maxProjecteis = data.maxProjecteis;
            _projectilSpeed = data.projectilSpeed;
            _projectilSpeed = data.projectilLifeTime;
        }

        public void EnterState()
        {
            Debug.Log("Enter Magical Attack State");
            _boss.animator.SetBool("isFlying", false);
            _boss.animator.SetBool("isDashing", false);

            HandleState();
        }

        public void HandleState()
        {
            _boss.OnCastMagic();
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