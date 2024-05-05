using UnityEngine;
using JAM.Movements;
using System;
using JAM.Animations;
using JAM.InputManagement;

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
        public InputHandler input { private set; get; }

        #endregion Components Unity

        #region Others components
        public CharacterBase character { private set; get; }
        public Movement movement { private set; get; }

        #endregion

        public CharacterComponents(CharacterBase character)
        {
            this.character = character;
            characterRigidbody2D = character.GetComponentInChildren<Rigidbody2D>();
            characterAnimator = character.GetComponentInChildren<Animator>();
            animatorController = character.GetComponentInChildren<AnimatorController>();
            spriteRenderer = character.GetComponentInChildren<SpriteRenderer>();
            movement = character.GetComponentInChildren<Movement>();
            input = character.GetComponent<InputHandler>();
        }
    }
}