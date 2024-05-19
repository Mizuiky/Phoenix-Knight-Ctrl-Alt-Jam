using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using JAM.Health;

namespace Assets.Scripts.Abilities.Enemy
{
    public class Enemy : MonoBehaviour, IDamageable
    {

        private GameObject player;
        private Rigidbody2D rb;
        private Transform target;
        private float speedMovement = 2;
        private SpriteRenderer sr;
        private float distanciaMin = 0.5f;
        private IHealth _health;


        [SerializeField]
        private float visionRadius = 3f;

        [SerializeField]
        private LayerMask LayerVisionRadius;


        void Awake()
        {
            _health = GetComponent<IHealth>();
            rb = this.GetComponent<Rigidbody2D>();
            sr = this.GetComponentInChildren<SpriteRenderer>();
            player = GameObject.Find("Player");

            target = player.transform;
        }

        public void OnEnable()
        {
            _health.OnKill += OnKill;
        }
            void Start()
        {
            _health.Init();
        }

      

        // Update is called once per frame
        void Update()
        {
            SearchPlayer();
            if (this.target != null)
            {
                Move();
            }
            else
            {
                StopMove();

            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(this.transform.position, visionRadius);
        }

        private void SearchPlayer()
        {
            Collider2D collider = Physics2D.OverlapCircle(this.transform.position, visionRadius, this.LayerVisionRadius);
            // Ao invés de comparar com a tag Player podemos usar o Layer
            bool achouPlayer = collider != null;
            this.target = achouPlayer ? collider.transform : null;
        }

        private void Move()
        {
            Vector2 targetPosition = this.target.position;
            Vector2 currentPosition = this.transform.position;

            float distancia = Vector2.Distance(currentPosition, targetPosition);

            if (distancia >= this.distanciaMin)
            {
                Vector2 direction = (targetPosition - currentPosition).normalized;

                rb.velocity = (direction * speedMovement);
                sr.flipX = (rb.velocity.x <= 0);
            }
            else
            {
                StopMove();
            }
        }
        private void StopMove()
        {
            this.rb.velocity = Vector2.zero;
        }


        public void Damage(float damage)
        {
            _health.OnDamage(damage);
        }

        public void Damage(Vector2 direction, float damage)
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision);

            IDamageable damageable = player.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(4);
            }

        }

        private void OnKill()
        {
            Destroy(gameObject);
        }

        public void OnDisable()
        {
            _health.OnKill -= OnKill;
        }
    }
}
