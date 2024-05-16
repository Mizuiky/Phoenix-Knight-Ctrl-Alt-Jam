using JAM.Pools;
using UnityEngine;

namespace JAM.Projectils
{
    public class ProjectilBase : MonoBehaviour, IPoolable, IProjectil
    {
        [SerializeField] private ProjectilData _data;
        [SerializeField] private SpriteRenderer _spriteRenterer;
        
        private Vector3 _direction;
        private float _passedTime;

        public void Update()
        {
            if(_passedTime < _data.lifeTime)
            {
                transform.Translate(_direction * _data.speed * Time.deltaTime);

                _passedTime += Time.deltaTime;
                if (_passedTime >= _data.lifeTime)
                    Deactivate();
            }
        }

        public virtual void Init()
        {
            _passedTime = _data.lifeTime;
            _spriteRenterer.sprite = _data.sprite;
            transform.rotation = Quaternion.identity;

            gameObject.SetActive(false);            
        }

        public virtual void InitializeProjectil(Vector3 position, Transform direction)
        {
            transform.localPosition = position;
            transform.rotation = direction.rotation;
            _direction = direction.position;

            Activate();
        }

        public void Activate()
        {
            PlayParticle();
            gameObject.SetActive(true);
            _passedTime = 0f;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag(_data.tagToDamage))
            {
                IDamageable damageable = collision.GetComponent<IDamageable>();
                if (damageable != null)
                    damageable.Damage();
            }
        }

        private void PlayParticle()
        {

        }    

        public void Deactivate()
        {
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }     
    }
}
