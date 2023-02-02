using UnityEngine;

namespace Assets.Script
{
    public class PlayerHealth : MonoBehaviour
    {
        public int CurrentHealth = 100;

        public HealthBar HealthBar;
        public int maxHealth = 100;

        private void Start()
        {
            CurrentHealth = maxHealth;
            HealthBar.SetMaxHealth(maxHealth);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                TakeDamage(20);
            }
        }

        void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            HealthBar.SetHealth(CurrentHealth);
        }
    }
}