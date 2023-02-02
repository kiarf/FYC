using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;

    public void SetMaxHealth(int maxHealth)
    {
        Slider.maxValue = maxHealth;
        SetHealth(maxHealth);
    }

    public void SetHealth(int health)
    {
        Slider.value = health > Slider.maxValue ? Slider.maxValue : health;
    }
}