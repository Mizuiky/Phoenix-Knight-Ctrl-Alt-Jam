using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace JAM.Abilites
{
    public class PlayerAbilityController : MonoBehaviour
    {
        List<IPlayerAbility> _abilities = new List<IPlayerAbility>();

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
            foreach (IPlayerAbility ability in _abilities)
            {
                ability.SetInput(inputActions);
                ability.Enter();
                ability.HandleInput();
            }
        }

        private void Update()
        {
            foreach (IPlayerAbility ability in _abilities)
            {
                ability.HandleAbility();
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