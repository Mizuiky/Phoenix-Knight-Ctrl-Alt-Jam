using UnityEngine;
using JAM.Characters;

namespace JAM.Boss
{
    public class MagicAttackState : MonoBehaviour, IBossState
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