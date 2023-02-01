using UnityEngine;

namespace Assets.Script
{
    public class KillHitbox : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(transform.parent.parent.gameObject);
            }
        } 
    }
}
