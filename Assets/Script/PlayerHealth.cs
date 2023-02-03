using System.Collections;
using UnityEngine;

namespace Assets.Script
{
    public class PlayerHealth : MonoBehaviour
    {
        private const float InvicibilityFlashDelay = 0.15f;
        private bool _tookRecentDamages;

        public int currentHealth;
        public HealthBar healthBar;

        public int maxHealth;

        public SpriteRenderer spriteRenderer;

        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                TakeDamage(20);
            }
        }

        public void TakeDamage(int damage)
        {
            if (!_tookRecentDamages)
            {
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
                HandleInvulnerabilityFrames();
            }
        }

        private void HandleInvulnerabilityFrames()
        {
            StartCoroutine(WaitInvulnerabilityFrames());
            StartCoroutine(DrawInvulnerabilityFrames());
        }

        public IEnumerator WaitInvulnerabilityFrames()
        {
            _tookRecentDamages = true;
            yield return new WaitForSeconds(3f);
            _tookRecentDamages = false;
        }

        public IEnumerator DrawInvulnerabilityFrames()
        {
            while (_tookRecentDamages)
            {
                yield return ToggleVisibility(true);
                yield return ToggleVisibility(false);
            }
        }

        private IEnumerator ToggleVisibility(bool visible)
        {
            spriteRenderer.color = visible ? new Color(1f, 1f, 1f, 0f) : new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(InvicibilityFlashDelay);
        }
    }
}