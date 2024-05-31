using JAM.Pools;
using UnityEngine;

namespace JAM.Projectils
{
    public class ProjectilBase : MonoBehaviour, IPoolable, IProjectil
    {
        [SerializeField] private ProjectilData _data;
        [SerializeField] private SpriteRenderer _spriteRenterer;
        [SerializeField] private Collider2D _collider;
        
        protected Vector3 _direction;
        private float _elapsedTime;
        private float _damagePercent;

        public void Update()
        {
            if(_elapsedTime < _data.lifeTime)
            {
                transform.Translate(_direction * _data.speed * Time.deltaTime);

                _elapsedTime += Time.deltaTime;
                if (_elapsedTime >= _data.lifeTime)
                    Deactivate();
            }
        }

        public virtual void Init()
        {
            _elapsedTime = _data.lifeTime;
            _spriteRenterer.sprite = _data.sprite;
            transform.rotation = Quaternion.identity;
            _damagePercent = _data.damage * _data.damagePercent;
            _collider.enabled = true;

            gameObject.SetActive(false);            
        }

        public virtual void InitializeProjectil(Vector3 position, Vector2 direction, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            _direction = direction;

            Activate();
        }

        public void Activate()
        {
            PlayParticle();
            gameObject.SetActive(true);
            _elapsedTime = 0f;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag(_data.tagToDamage))
            {
                IDamageable damageable = collision.GetComponent<IDamageable>();
                if (damageable != null)
                    damageable.Damage(_damagePercent);
            }
        }

        private void PlayParticle()
        {

        }    

        public void Deactivate()
        {
            transform.rotation = Quaternion.identity;
            _collider.enabled = false;

            gameObject.SetActive(false);
        }
    }
}
