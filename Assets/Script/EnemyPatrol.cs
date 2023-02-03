using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Script
{
    public class EnemyPatrol : MonoBehaviour
    {
        private int _currentTarget;
        private Transform _currentTargetPosition;

        public const int DamageOnCollision = 20;

        public float speed;
        public SpriteRenderer spriteRenderer;
        public Transform[] targetsPosition;

        // Start is called before the first frame update
        private void Start()
        {
            _currentTargetPosition = targetsPosition[0];
        }

        // Update is called once per frame
        private void Update()
        {
            var dir = _currentTargetPosition.position - transform.position;
            transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);

            if (Vector3.Distance(transform.position, _currentTargetPosition.position) < 0.3f)
            {
                _currentTarget = (_currentTarget + 1) % targetsPosition.Length;
                _currentTargetPosition = targetsPosition[_currentTarget];
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                var playerHealth = collision.transform.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(DamageOnCollision);
            }
        }
    }
}