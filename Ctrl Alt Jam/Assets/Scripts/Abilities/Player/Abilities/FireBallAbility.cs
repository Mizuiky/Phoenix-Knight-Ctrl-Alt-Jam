using UnityEngine.InputSystem;
using UnityEngine;
using JAM.Projectils;

namespace JAM.Abilites
{
    public class FireBallAbility : PlayerAbilityBase<FireBallAbility>
    {
        [SerializeField] ProjectilLauncherBase _launcher;
        private InputAction _fireballSkill;
        
        public override void Enter()
        {
            base.Enter();

            _state = AbiliteState.Ready;
            _abilityType = AbilityType.Fireball;
        }

        public override void HandleInput()
        {
            _fireballSkill = _playerInputActions.SkillMap.FireBall;
            _fireballSkill.Enable();

            _fireballSkill.performed += ActivateAbility;
        }

        public override void Exit()
        {
            _fireballSkill.Disable();
            _fireballSkill.performed -= ActivateAbility;
        }

        public override void HandleAbility()
        {
            Debug.Log("Play fireball");
            _character.characterComponents.animatorController.PlayAttack();
            _launcher.LaunchProjectil();
        }
    }
}