using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Gradient gradient;
    public Image healthBarFill;
    public Slider slider;

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        SetHealth(maxHealth);

        healthBarFill.color = gradient.Evaluate(1);
    }

    public void SetHealth(int health)
    {
        slider.value = health > slider.maxValue ? slider.maxValue : health;
        healthBarFill.color = gradient.Evaluate(slider.normalizedValue);
    }
}