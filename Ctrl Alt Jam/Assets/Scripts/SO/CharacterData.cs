using JAM.Characters;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Character")]
public class CharacterData : ScriptableObject
{
    [Tooltip("Character sprite render.")]
    public Sprite characterSpriteRender;

    [SerializeField]
    [Tooltip("Character Type.")]
    public CharacterType characterType;

    [Range(0, 2)]
    [Tooltip("Direction for character.")]
    public int characterAnimationDirection = 2;

    [Range(0, 10)]
    [Tooltip("Maximum speed for character.")]
    public float currentVelocity = 0;

    [Range(0, 10)]
    [Tooltip("Maximum speed for character.")]
    public float originMaxSpeed = 0;

    [Tooltip("Maximum speed for character.")]
    public Vector2 movementInput = Vector2.zero;

    [Range(0, 1000)]
    [Tooltip("Maximum speed for character.")]
    public float maxSpeed = 5;

    [Range(0.1f, 100)]
    [Tooltip("Acceleration speed for character.")]
    public float acceleration = 20;

    [Range(0.1f, 100)]
    [Tooltip("Deceleration speed for character.")]
    public float deceleration = 20;

    //public CharacterData()
    //{
    //    originMaxSpeed = maxSpeed;
    //}
}
