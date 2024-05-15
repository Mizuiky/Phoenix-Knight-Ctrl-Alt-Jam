using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JAM.Abilites
{
    public class LightUpAbility : PlayerAbilityBase<LightUpAbility>
    {
        [SerializeField] private float _dectionRadius;
        [SerializeField] private LayerMask _detectionLayer;

        private InputAction _lightSkill;
        private Collider2D[] _results;

        public override void Enter()
        {
            base.Enter();

            _state = AbiliteState.Ready;
            _abilityType = AbilityType.LightUp;
            _results = new Collider2D[2];
        }

        public override void HandleInput()
        {
            _lightSkill = _playerInputActions.SkillMap.LightUp;
            _lightSkill.Enable();

            _lightSkill.performed += ChangeAbilityState;
        }

        public override void Exit()
        {
            _lightSkill.Disable();
            _lightSkill.performed -= ChangeAbilityState;
        }

        public override void HandleAbility()
        {
            Debug.Log("Get Torch in range"); 

            int count = Physics2D.OverlapCircleNonAlloc(transform.position, _dectionRadius, _results, _detectionLayer);

            if (count > 0)
            {
                IInteractable torch = _results[0].gameObject.GetComponent<IInteractable>();
                if (torch != null)
                {
                    torch.Interact();
                    return;
                }     
            }

            Debug.Log("Torch not in range");
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _dectionRadius);
        }
    }
}
