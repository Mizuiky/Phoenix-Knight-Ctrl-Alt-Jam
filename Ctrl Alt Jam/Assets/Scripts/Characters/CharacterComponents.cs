using UnityEngine;
using System;
using JAM.Animations;
using JAM.Movement;

namespace JAM.Characters
{
    [Serializable]
    public class CharacterComponents
    {
        #region Unity Components

        public Rigidbody2D characterRigidbody2D { private set; get; }
        public Animator characterAnimator { private set; get; }
        public AnimatorController animatorController { private set; get; }
        public SpriteRenderer spriteRenderer { private set; get; }
        public MovementBase movement { private set; get; }
        public IPlayerMovement playerMovement { private set; get; }

        #endregion Components Unity

        #region Others components
        public CharacterBase character { private set; get; }

        #endregion

        public CharacterComponents(CharacterBase character)
        {
            this.character = character;
            characterRigidbody2D = character.GetComponentInChildren<Rigidbody2D>();
            characterAnimator = character.GetComponentInChildren<Animator>();
            animatorController = character.GetComponentInChildren<AnimatorController>();
            spriteRenderer = character.GetComponentInChildren<SpriteRenderer>();
            movement = character.GetComponent<MovementBase>();
            playerMovement = movement.GetComponent<IPlayerMovement>();
        }
    }
}