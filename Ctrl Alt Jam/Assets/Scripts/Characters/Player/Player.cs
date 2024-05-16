using JAM.Abilites;
using JAM.InputManagement;
using JAM.Projectils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JAM.Characters
{
    [AddComponentMenu("JAM/Characters/Player")]
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(-1)]
    [RequireComponent(typeof(InputHandler))]
    public class Player : CharacterBase, IDamageable
    {
       [SerializeField] private PlayerAbilityController _abilityController;
       [SerializeField] private MagicLauncher _magicLauncher;

       private PlayerInputActions _playerActions;
       private InputAction _movement;

        public override void Awake()
        {
            base.Awake();
            _playerActions = new PlayerInputActions();
        }

        public void OnEnable()
        {
            _movement = _playerActions.PlayerMap.Movement;
            _movement.Enable();
        }

        public void Start()
        {
            Init();
        }

        public void Init()
        {
            _abilityController.Init(_playerActions);
            _magicLauncher.Init(this);

            //playerActions.PlayerMap.Movement.performed += SetMovement;              
        }

        public void SetMovement(InputAction.CallbackContext value)
        {

        }

        public void OnActivateFireBallSkill(InputAction.CallbackContext value)
        {
            Debug.Log("fIREBALL");
        }

        public void PlaySkill(InputAction.CallbackContext value)
        {
            Debug.Log("Space pressed");
        }

        public void Damage()
        {
            throw new System.NotImplementedException();
        }

        public void Damage(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }
    }
}