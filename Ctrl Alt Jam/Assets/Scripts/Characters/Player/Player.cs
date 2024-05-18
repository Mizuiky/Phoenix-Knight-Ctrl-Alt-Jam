using JAM.Abilites;
using JAM.Projectils;
using JAM.Movement;
using UnityEngine;
using UnityEngine.InputSystem;
using JAM.Health;

namespace JAM.Characters
{
    [AddComponentMenu("JAM/Characters/Player")]
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(-1)]
    public class Player : CharacterBase, IDamageable
    {
       [SerializeField] private PlayerAbilityController _abilityController;
       [SerializeField] private ProjectilLauncherBase _launcher;

       private PlayerInputActions _playerActions;
       private InputAction _movement;
       public IPlayerMovement playerMovement { private set; get; }
       private IHealth _health;

       private Vector2 _movementInput;
       private Transform _currentPosition;

       public override void Awake()
       {
           base.Awake();
           _playerActions = new PlayerInputActions();
           _launcher = GetComponentInChildren<ProjectilLauncherBase>();
           _health = GetComponent<IHealth>();
       }

       public void OnEnable()
       {
           _movement = _playerActions.PlayerMap.Movement;
           _movement.Enable();

           _movement.performed += SetInput;
           _movement.canceled += ResetInput;

           _health.OnKill += OnKill;
       }

        public void Start()
        {
            Init();
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log("cliquei h");
                Damage(4);
            }
        }

        public void Init()
        {
            playerMovement = characterComponents.movement.GetComponent<IPlayerMovement>();
            _abilityController.Init(_playerActions);
            _launcher.Init(this);
            _health.Init();
        }

        public void Reset()
        {
            _movement.Reset();
            _health.Reset();
            _abilityController.Reset();

            SetPosition();
        }

        public void SetInput(InputAction.CallbackContext value)
        {
            _movementInput = value.ReadValue<Vector2>();
            playerMovement.SetMovementInput(_movementInput);
        }

        public void ResetInput(InputAction.CallbackContext value)
        {
            _movementInput = Vector2.zero;
            playerMovement.SetMovementInput(_movementInput);
        }

        public void Damage(float damage)
        {
            //feedback de dano
            //som de dano
            Debug.Log("Damage");
            _health.OnDamage(damage);
        }

        public void Damage(Vector2 direction, float damage)
        {
            //feedback de dano
            //som de dano
            _health.OnDamage(damage);
        }

        private void SetPosition()
        {

        }

        public void OnKill()
        {
            //setando player morto e avisando tudo do mundo disso para poder parar
            //som de player morrendo
            //animacao player morrendo
            //animacao player voltando das cinzas depois de um tempo com a musica da nati
        }

        public void OnDisable()
        {
            _movement.Disable();
            _movement.performed -= SetInput;
            _movement.canceled -= ResetInput;
        }
    }
}