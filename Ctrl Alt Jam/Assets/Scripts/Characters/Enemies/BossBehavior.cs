using JAM.Health;
using JAM.Movement;
using JAM.Projectils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

namespace JAM.Boss
{
    public enum BossState
    {
        Idle,
        Search,
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
        [SerializeField] private BossFuriaData _data;

        private Dictionary<BossState, IBossState> _stateMachine;
        private IBossState _currentState;
        private IHealth _health;

        private GameObject _bossTarget;
        public GameObject BossTarget { get { return _bossTarget; } set { _bossTarget = value; } }
        
        private bool _isAlive = false;
        public bool IsAlive { get { return _isAlive; } }

        #region Boss Components
        public Rigidbody2D rb { private set; get; }
        public Animator animator { private set; get; }
        public BossMovement movement { private set; get; }
        public ProjectilLauncherBase launcher { private set; get; }

        #endregion

        private void Awake()
        {
            LoadComponents();
        }

        public void Start()
        {
            Init();   
        }

        public void OnEnable()
        {
            _health.OnKill += OnKill;
        }

        public void Init()
        {
            _health.Init();

            _stateMachine = new Dictionary<BossState, IBossState>(); 
            
            launcher.Init();
            //movement.Init(_data);

            //RegisterStates();

            _isAlive = true;
        }

        private void LoadComponents()
        {
            _health = GetComponent<IHealth>();
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
            movement  = GetComponent<BossMovement>();       
            launcher = GetComponentInChildren<ProjectilLauncherBase>();
        }

        public void Reset()
        {
            _currentState = _stateMachine[BossState.Idle];
            _currentState.EnterState();
            _health.Reset();
            _isAlive = true;
        }

        private void RegisterStates()
        {
            _stateMachine.Add(BossState.Idle, new IdleState(this, _data));
            _stateMachine.Add(BossState.Search, new SearchState(this, _data));
            _stateMachine.Add(BossState.Chasing, new ChasingState(this, _data));
            _stateMachine.Add(BossState.Dash, new DashAttackState(this, _data));
            _stateMachine.Add(BossState.MagicAttack, new MagicAttackState(this, _data));
            _stateMachine.Add(BossState.Dead, new DeadState(this, _data));

            _currentState = _stateMachine[BossState.Idle];
            _currentState.EnterState();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                OnCastMagic();
            }

            //if(_isAlive)
             //_currentState.HandleStateInLoop();
        }

        private void FixedUpdate()
        {
            //if (_isAlive)
                //_currentState.StatePhysicsUpdate();
        }

        public void OnChangeState(BossState state)
        {
            Debug.Log("on change state");
            if(_currentState != null)
                _currentState.ExitState();

            _currentState = _stateMachine[state];

            Debug.Log("current state" + state.ToString());
            _currentState.EnterState();          
        }

        public void OnCastMagic()
        {
            Debug.Log("CAST SPEEL");
            launcher.LaunchProjectil();
        }

        public void Damage(float damage)
        {
            _health.OnDamage(damage);
        }

        public void Damage(Vector2 direction, float damage)
        {

        }

        public void OnKill()
        {
            _isAlive = false;
            //particula de kill
            //som de kill
        }

        public void OnDisable()
        {
            _health.OnKill -= OnKill;
        }

        private void OnApplicationQuit()
        {     
            // _currentState.ExitState();            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _data.detectionRadius);
        }
    }
}