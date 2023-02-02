using UnityEngine;

namespace Assets.Script
{
    public class PlayerHealth : MonoBehaviour
    {
        public int currentHealth;
        public HealthBar healthBar;
        public int maxHealth;

        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        private void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                TakeDamage(20);
            }
        }
    }
}