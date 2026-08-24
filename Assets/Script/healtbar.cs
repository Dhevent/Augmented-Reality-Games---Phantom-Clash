using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Image fillImage;   
    public Gradient gradient;     
    private int maxHealth;

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        SetHealth(health);
    }

    public void SetHealth(int health)
    {
        float normalized = (float)health / maxHealth;
        fillImage.fillAmount = normalized;
        fillImage.color = gradient.Evaluate(normalized);
    }
}
