using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abilities.Enemy
{
    public class Enemy : MonoBehaviour
    {

        private GameObject player;
        private Rigidbody2D rb;
        private Transform target;
        private float speedMovement = 2;
        private SpriteRenderer sr;
        private float distanciaMin = 0.9f;

        [SerializeField]
        private float visionRadius = 3f;


        void Start()
        {
            rb = this.GetComponent<Rigidbody2D>();
            sr = this.GetComponentInChildren<SpriteRenderer>();
            player = GameObject.Find("Player");
            target = player.transform;

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
            Gizmos.DrawSphere(this.transform.position, visionRadius);
        }

        private void SearchPlayer()
        {
            Collider2D collider = Physics2D.OverlapCircle(this.transform.position, visionRadius);
            // Ao invés de comparar com a tag Player podemos usar o Layer
            bool achouPlayer = collider != null && collider.CompareTag("Player");
            
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
    }
}
