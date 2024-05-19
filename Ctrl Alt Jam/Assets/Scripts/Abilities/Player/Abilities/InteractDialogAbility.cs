using JAM.Dialog;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JAM.Abilites
{
    public class InteractDialogAbility : PlayerAbilityBase<InteractDialogAbility>
    {
        [SerializeField] private float _dectionRadius;
        [SerializeField] private LayerMask _detectionLayer;

        private InputAction _interactSkill;
        private Collider2D[] _results;

        public override void Enter()
        {
            base.Enter();

            _state = AbiliteState.Active;
            _abilityType = AbilityType.Interact;
            _results = new Collider2D[2];
        }

        public override void HandleInput()
        {
            _interactSkill = _playerInputActions.SkillMap.Interact;
            _interactSkill.Enable();

            _interactSkill.performed += ActivateAbility;
        }

        protected override void ActivateAbility(InputAction.CallbackContext value)
        {
            int count = Physics2D.OverlapCircleNonAlloc(transform.position, _dectionRadius, _results, _detectionLayer);

            if (count > 0)
            {
                Debug.Log("Try to interact");

                IDialogTrigger dialog = _results[0].gameObject.GetComponent<IDialogTrigger>();
                if (dialog != null)
                {
                    Debug.Log("OnStartDialog");
                    dialog.OnStartDialog();
                }               
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, _dectionRadius);
        }
    }
}