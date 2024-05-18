using JAM.Health;
using JAM.Movement;
using JAM.Projectils;
using System.Collections.Generic;
using UnityEngine;

namespace JAM.Boss
{
    public enum BossState
    {
        Idle,
        Wait,
        Chasing,
        Dash,
        MagicAttack,   
        Dead
    }

    public enum BossAnimationType
    {
        Idle,
        Fly,
        Attack 
    }

    public class BossBehavior : MonoBehaviour, IDamageable
    {
        [SerializeField] private CharacterData _data;

        private Dictionary<BossState, IState> _stateMachine;
        private IState _currentState;
        private IHealth _health;

        private ProjectilLauncherBase _launcher;
        private GameObject _currentTarget;

        private bool _isAlive = false;
        public bool IsAlive { get { return _isAlive; } }

        #region Boss Components
        public Rigidbody2D rb { private set; get; }
        public Animator animator { private set; get; }
        public BossMovement movement { private set; get; }

        #endregion

        public void Start()
        {
            Init();   
        }

        public void Init()
        {
            _stateMachine = new Dictionary<BossState, IState>();
            _launcher = GetComponentInChildren<ProjectilLauncherBase>();
            _health = GetComponent<IHealth>();

            LoadComponents();

            AddStates();
        }

        private void LoadComponents()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
            movement  = GetComponent<BossMovement>();
            movement.Init(_data);
        }

        public void Reset()
        {
            _currentState = _stateMachine[BossState.Idle];
            _currentState.EnterState();
            _health.Reset();
        }

        private void AddStates()
        {
            _stateMachine.Add(BossState.Idle, new IdleState());
            _stateMachine.Add(BossState.Wait, new WaitState());
            _stateMachine.Add(BossState.Chasing, new ChasingState());
            _stateMachine.Add(BossState.Dash, new DashAttackState());
            _stateMachine.Add(BossState.MagicAttack, new MagicAttackState());
            _stateMachine.Add(BossState.Dead, new DeadState());

            _currentState = _stateMachine[BossState.Idle];
            _currentState.EnterState();
        }

        private void Update()
        {
            _currentState.HandleStateInLoop();
        }

        private void FixedUpdate()
        {
            _currentState.StatePhysicsUpdate();
        }

        public void OnChangeState(BossState state)
        {
            if(_currentState != null)
                _currentState.ExitState();

            _currentState = _stateMachine[state];
            _currentState.EnterState();          
        }

        private void SetAnimation(string trigger)
        {
            
        }

        public void Damage(float damage)
        {

        }
        public void Damage(Vector2 direction, float damage)
        {

        }

        private void OnApplicationQuit()
        {     
             _currentState.ExitState();            
        }
    }
}