using UnityEngine;

namespace JAM.Characters
{
    [CreateAssetMenu(menuName = "Data/Boss/Furia")]
    public class BossFuriaData : ScriptableObject
    {
        [SerializeField]
        [Tooltip("Character Type.")]
        public CharacterType characterType;

        [Range(0, 10)]
        [Tooltip("Maximum speed for character.")]
        public float currentVelocity = 0;

        [Range(0, 10)]
        [Tooltip("Maximum original for character.")]
        public float originMaxSpeed = 3;

        [Tooltip("Maximum speed for character.")]
        public Vector2 movementInput = Vector2.zero;

        [Range(0, 1000)]
        [Tooltip("Maximum speed for character.")]
        public float maxSpeed = 3;

        [Range(0.1f, 100)]
        [Tooltip("Acceleration speed for character.")]
        public float acceleration = 5;

        [Range(0.1f, 100)]
        [Tooltip("Deceleration speed for character.")]
        public float deceleration = 10;

        [Space(3)]
        [Header("Damage value")]
        public float bossDamage;

        [Space(3)]
        [Header("Idle State")]
        public float timeToNextState;

        [Space(2)]
        [Header("Search State")]
        public float detectionRadius;
        public LayerMask detectionLayer;

        [Space(2)]
        [Header("Chase State")]
        public float minDistanceToAttack;
        public float timeToStartChasing;

        [Space(2)]
        [Header("DashAttack State")]
        public float maxAcceleration;

        [Space(2)]
        [Header("MagicAttack State")]
        public int maxProjecteis;
        public float projectilSpeed;
        public float projectilLifeTime;
    }
}
