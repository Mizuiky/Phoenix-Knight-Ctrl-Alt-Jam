using UnityEngine;
using System;

namespace JAM.Characters
{
    public enum CharacterType
    {
        Player,
        IA,
        NPC,
    }

    [Serializable]
    public abstract class CharacterBase : MonoBehaviour
    {
        [Tooltip("Sets character data.")]
        public CharacterData characterData;

        [Tooltip("Gets character components.")]
        public CharacterComponents characterComponents;

        private bool _isAlive = false;
        public bool IsAlive { get { return _isAlive; } }

        public virtual void Awake()
        {
            LoadComponents();
        }

        private void LoadComponents()
        {
            characterComponents = new CharacterComponents(this);
        }

        private void OnValidate()
        {
            LoadComponents();
        }
    }
}