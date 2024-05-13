using UnityEngine;
using JAM.Characters;
using System;

namespace JAM.Movements
{
    [AddComponentMenu("JAM/Movements/Movement")]
    public class Movement : MonoBehaviour
    {
        private CharacterBase _character;
        private Rigidbody2D _rb;
        private IMovementUpdater _movementEvents;
        private Vector2 velocity;
        [SerializeField] private bool isAbility;
        [HideInInspector] public Vector2 currentPosition { get; private set; }

        public void Awake()
        {
            _character = GetComponent<CharacterBase>();
            _movementEvents = _character.characterEvents;
            _movementEvents.OnMovementVelocityNormal().AddListener(OnMovementVelocityNormal);
            _movementEvents.OnMovementPositionNormal().AddListener(OnMovementPositionNormal);
        }
        private void Start()
        {
            _rb = _character.characterComponents.characterRigidbody2D;
            _character.characterData.originMaxSpeed = _character.characterData.maxSpeed;
        }

        public void OnDisableAbility()
        {
            isAbility = false;
        }
        public void OnMovementVelocityNormal(Vector2 velocity)
        {
            if (!isAbility)
            {
                this.velocity = velocity;
                Move();
            }
        }

        public void OnMovementPositionNormal(Vector2 velocity)
        {
            if (!isAbility)
            {
                this.velocity = velocity;
                MovePosition();
            }
        }

        private void Move()
        {
            _rb.velocity = velocity;
        }
        private void MovePosition()
        {
            _rb.MovePosition(velocity);
        }

        private void OnDestroy()
        {
            _movementEvents?.OnMovementVelocityNormal()?.RemoveListener(OnMovementVelocityNormal);
            _movementEvents?.OnMovementPositionNormal()?.RemoveListener(OnMovementPositionNormal);
        }
    }
}
