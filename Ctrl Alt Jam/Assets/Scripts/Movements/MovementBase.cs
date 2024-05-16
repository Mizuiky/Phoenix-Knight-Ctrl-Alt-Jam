using JAM.Animations;
using JAM.Characters;
using UnityEngine;

namespace JAM.Movement
{
    public class MovementBase : MonoBehaviour
    {
        protected CharacterBase _character;
        protected Rigidbody2D _rb;
        protected AnimatorController _animatorController;
        
        protected Vector2 _movementInput = Vector3.zero;
        private Vector2 _movementDirection;
        public Vector2 MovementDirection { get { return _movementDirection; } }
       
        private float _currentVelocity = 0;
        private Vector2 _velocity;

        private void Awake()
        {
            _character = GetComponent<CharacterBase>();
            _rb = _character.characterComponents.characterRigidbody2D;
            _character.characterData.originMaxSpeed = _character.characterData.maxSpeed;
            _animatorController = _character.characterComponents.animatorController;
        }

        protected virtual void Update()
        {
            _animatorController.Play(_movementInput * _currentVelocity);
            if (_movementInput.magnitude > 0)
            {
                if (Vector2.Dot(_movementInput.normalized, _movementDirection) < 0)
                {
                    _currentVelocity = 0;
                }
                _movementDirection = _movementInput.normalized;
            }
            _currentVelocity = CalculateSpeed(_movementInput);
        }

        public float CalculateSpeed(Vector2 movementInput)
        {
            if (movementInput.magnitude > 0)
            {
                _currentVelocity += _character.characterData.acceleration * Time.deltaTime;
            }
            else
            {
                _currentVelocity -= _character.characterData.deceleration * Time.deltaTime;
            }
            return Mathf.Clamp(_currentVelocity, 0, _character.characterData.maxSpeed);
        }

        protected virtual void FixedUpdate()
        {
            if (_movementDirection == Vector2.zero) return;

            _character.characterData.currentVelocity = _currentVelocity;
            Vector2 movement = _movementDirection.normalized * _currentVelocity;
            SetNormalVelocity(movement);
        }

        public void SetNormalVelocity(Vector2 velocity)
        {        
            _velocity = velocity;
            Move();           
        }

        protected virtual void Move()
        {
            _rb.velocity = _velocity;
        }

        protected virtual void MoveToPosition(Vector2 velocity)
        {        
            _velocity = velocity;
            _rb.MovePosition(velocity);
        }
    }
}