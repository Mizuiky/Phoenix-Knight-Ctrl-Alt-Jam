using UnityEngine;

namespace JAM.Projectils
{
    public class ProjectilBase : MonoBehaviour, IProjectil
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private ParticleSystem _projectilParticle;

        [SerializeField] private int _damage;    
        [SerializeField] private string _tagToDamage;
        [SerializeField] private float _lifeTime, _passedTime;
        [SerializeField] private float _speed;
        
        private Vector3 _direction;

        public void Awake()
        {
            _passedTime = _lifeTime;
        }

        public void Update()
        {
            if(_passedTime < _lifeTime)
            {
                transform.position += _direction * _speed * Time.deltaTime;

                _passedTime += Time.deltaTime;
                if (_passedTime >= _lifeTime)
                    Deactivate();
            }
        }

        public void Init(Vector3 direction, Vector3 position)
        {
            transform.position = position;
            _direction = direction;

            PlayParticle();
            _passedTime = 0f;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag(_tagToDamage))
            {
                IDamageable damageable = collision.GetComponent<IDamageable>();
                if (damageable != null)
                    damageable.Damage();
            }
        }


        private void PlayParticle()
        {

        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
