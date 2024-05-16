using JAM.Abilites;
using JAM.Projectils;
using JAM.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JAM.Characters
{
    [AddComponentMenu("JAM/Characters/Player")]
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(-1)]
    [RequireComponent(typeof(PlayerMovementController))]
    public class Player : CharacterBase, IDamageable
    {
       [SerializeField] private PlayerAbilityController _abilityController;
       [SerializeField] private ProjectilLauncher _magicLauncher;

       private PlayerInputActions _playerActions;
       private InputAction _movement;
       private Vector2 _movementInput;

        public override void Awake()
        {
            base.Awake();
            _playerActions = new PlayerInputActions();
        }

        public void OnEnable()
        {
            _movement = _playerActions.PlayerMap.Movement;
            _movement.Enable();

            _movement.performed += SetInput;
            _movement.canceled += ResetInput;
        }

        public void Start()
        {
            Init();
        }

        public void Init()
        {
            _abilityController.Init(_playerActions);
            _magicLauncher.Init(this);             
        }

        public void SetInput(InputAction.CallbackContext value)
        {
            _movementInput = value.ReadValue<Vector2>();
            characterComponents.playerMovement.SetMovementInput(_movementInput);
        }

        public void ResetInput(InputAction.CallbackContext value)
        {
            _movementInput = Vector2.zero;
            characterComponents.playerMovement.SetMovementInput(_movementInput);
        }

        public void OnActivateFireBallSkill(InputAction.CallbackContext value)
        {
            Debug.Log("fIREBALL");
        }

        public void Damage()
        {
            throw new System.NotImplementedException();
        }

        public void Damage(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }

        public void OnDisable()
        {
            _movement.Disable();
            _movement.performed -= SetInput;
            _movement.canceled -= ResetInput;
        }
    }
}