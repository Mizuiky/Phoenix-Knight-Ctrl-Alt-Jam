using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

namespace JAM.Abilites
{
    public class PlayerAbilityController : MonoBehaviour
    {
        List<IPlayerAbility> _abilities = new List<IPlayerAbility>();
        private AbilityType _currentActiveAbility;

        private InputAction _playSkill;

        void OnValidate()
        {
            _abilities.Clear();
            _abilities = GetComponents<IPlayerAbility>().ToList();
        }

        private void Awake()
        {
            _abilities = GetComponents<IPlayerAbility>().ToList();
        }

        public void Init(PlayerInputActions inputActions)
        {
            _playSkill = inputActions.SkillMap.PlaySkill;
            _playSkill.Enable();

            _playSkill.performed += PlayAbility;

            _currentActiveAbility = AbilityType.None;

            foreach (IPlayerAbility ability in _abilities)
            {
                ability.OnActivateAbility += SetCurrentActiveAbility;
                ability.SetInput(inputActions);
                ability.Enter();
                ability.HandleInput();
            }
        }

        public void Reset()
        {
            foreach (IPlayerAbility ability in _abilities)
            {
                ability.ResetAbility();
            }
        }

        public void SetCurrentActiveAbility(AbilityType type)
        {
            _currentActiveAbility = type;

            Debug.Log("Set current ability");

            foreach (IPlayerAbility ability in _abilities)
            {
                if (ability.Type != _currentActiveAbility && ability.State == AbiliteState.Active)
                    ability.ResetAbility();
            }
        }

        private void PlayAbility(InputAction.CallbackContext value)
        {           
            foreach (IPlayerAbility ability in _abilities)
            {
                Debug.Log("state" + ability.State.ToString());

                if (ability.Type == _currentActiveAbility && ability.State == AbiliteState.Active)
                {
                    Debug.Log("play ability" + ability.Type.ToString());
                    ability.HandleAbility();
                    return;
                }
            }          
        }

        private void Update()
        {
            foreach (IPlayerAbility ability in _abilities)
            {
                ability.HandleAbilityInLoop();
            }
        }

        private void FixedUpdate()
        {
            foreach (IPlayerAbility ability in _abilities)
            {
                ability.PhysicsUpdate();
            }
        }

        private void OnDisable()
        {
            OnApplicationQuit();
        }

        private void OnDestroy()
        {
            OnApplicationQuit();
        }

        private void OnApplicationQuit()
        {
            foreach (IPlayerAbility ability in _abilities)
            {
                ability.Exit();
            }
        }
    }
}