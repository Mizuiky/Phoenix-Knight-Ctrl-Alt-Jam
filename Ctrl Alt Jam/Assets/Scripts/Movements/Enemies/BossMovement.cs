using JAM.Characters;
using UnityEngine;

namespace JAM.Movement
{
    public class BossMovement : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Animator _animator;
        private BossFuriaData _data;

        private Vector2 _movementInput;
        private Vector2 _movementDirection;
        private Vector2 _velocity;
        private Vector2 _direction;

        private float _currentVelocity = 0;
        private float _currentSpeed;
        private float _startSpeed;
        private string _animationName;

        public float Speed { get { return _currentSpeed; } set { _currentSpeed = value; } }
        public Vector2 Movementinput { get { return _movementInput; } set { _movementInput = value; } }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
        }

        public void OnValidate()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
        }


        public void Init(BossFuriaData data)
        {
            _data = data;
            _startSpeed = data.originMaxSpeed;
            Reset();
        }

        public virtual void Reset()
        {
            _movementInput = Vector2.zero;
            _movementDirection = Vector3.zero;
            _currentVelocity = 0f;
            _currentSpeed = _startSpeed;
        }

        private void Update()
        {
            if (_movementInput != Vector2.zero)
            {
                _direction = _movementInput * _currentVelocity;
                if (_direction == Vector2.zero)
                {
                    _animationName = "Idle";
                }
                else if (_direction != Vector2.zero || _direction.magnitude != 0)
                {
                    _animationName = "Fly";
                }
                _animator.Play(_animationName);

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
        }

        public float CalculateSpeed(Vector2 movementInput)
        {
            if (movementInput.magnitude > 0)
            {
                _currentVelocity += _data.acceleration * Time.deltaTime;
            }
            else
            {
                _currentVelocity -= _data.deceleration * Time.deltaTime;
            }
            return Mathf.Clamp(_currentVelocity, 0, _currentSpeed);
        }

        private void FixedUpdate()
        {
            if (_movementDirection == Vector2.zero) return;

            _data.currentVelocity = _currentVelocity;
            Vector2 movement = _movementDirection.normalized * _currentVelocity;
            SetNormalVelocity(movement);
        }

        private void SetNormalVelocity(Vector2 velocity)
        {
            _velocity = velocity;
            Move();
        }

        private void Move()
        {
            _rb.velocity = _velocity;
        }
    }
}