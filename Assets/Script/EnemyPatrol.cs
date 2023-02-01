using UnityEngine;

namespace Assets.Script
{
    public class EnemyPatrol : MonoBehaviour
    {
        private int _currentTarget;
        private Transform _currentTargetPosition;

        public float Speed;
        public SpriteRenderer SpriteRenderer;
        public Transform[] TargetsPosition;

        // Start is called before the first frame update
        private void Start()
        {
            _currentTargetPosition = TargetsPosition[0];
        }

        // Update is called once per frame
        private void Update()
        {
            var dir = _currentTargetPosition.position - transform.position;
            transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, _currentTargetPosition.position) < 0.3f)
            {
                _currentTarget = (_currentTarget + 1) % TargetsPosition.Length;
                _currentTargetPosition = TargetsPosition[_currentTarget];
                SpriteRenderer.flipX = !SpriteRenderer.flipX;
            }
        }
    }
}