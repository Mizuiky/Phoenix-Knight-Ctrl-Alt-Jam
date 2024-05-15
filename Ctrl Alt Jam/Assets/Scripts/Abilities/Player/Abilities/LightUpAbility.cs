using UnityEngine;
using UnityEngine.InputSystem;

namespace JAM.Abilites
{
    public class LightUpAbility : PlayerAbilityBase<LightUpAbility>
    {
        [SerializeField] private float dectionRadius;
        [SerializeField] private LayerMask detectionLayer;

        private InputAction _lightSkill;

        private Collider2D[] results;
        public override void Enter()
        {
            base.Enter();

            _lightSkill = _playerInputActions.SkillMap.LightUp;
            _lightSkill.Enable();

            _lightSkill.performed += GetTorchInRange;

            results = new Collider2D[2];
            //logica que reseta a ui indicando que pode usar habilidade
        }

        public override void HandleInput()
        {
            
        }

        public override void Exit()
        {
            _lightSkill.Disable();
            _lightSkill.performed -= GetTorchInRange;
            //volta a cor da ui normal
        }

        public void GetTorchInRange(InputAction.CallbackContext value)
        {
            Debug.Log("Gettorch in range");
            int count = Physics2D.OverlapCircleNonAlloc(transform.position, dectionRadius, results, detectionLayer);

            if(count > 0) 
            {
                IInteractable torch = results[0].gameObject.GetComponent<IInteractable>();
                if (torch != null)
                    torch.Interact();
            }          
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, dectionRadius);
        }
    }
}
