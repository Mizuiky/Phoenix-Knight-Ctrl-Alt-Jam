using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace JAM.Abilites
{
    [AddComponentMenu("JAM/Abilities/Enemy Ability Controller")]
    [DisallowMultipleComponent]

    public sealed class EnemyAbilityController : MonoBehaviour
    {
        List<IEnemyAbility> _abilities = new List<IEnemyAbility>();

        void OnValidate()
        {
            _abilities.Clear();
            _abilities = GetComponents<IEnemyAbility>().ToList();
        }

        private void Awake()
        {
            enabled = false;
            _abilities = GetComponents<IEnemyAbility>().ToList();
        }

        private void Start()
        {
            foreach (IEnemyAbility ability in _abilities)
            {
                ability.Enter();
                ability.HandleInput();
            }
        }

        private void Update()
        {
            foreach (IEnemyAbility ability in _abilities)
            {
                ability.HandleAbility();
            }
        }

        private void FixedUpdate()
        {
            foreach (IEnemyAbility ability in _abilities)
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
            foreach (IEnemyAbility ability in _abilities)
            {
                ability.Exit();
            }
        }
    }
}