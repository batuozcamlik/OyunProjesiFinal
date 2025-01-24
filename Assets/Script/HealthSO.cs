using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "HealthData", menuName = "Game/Health")]
public class HealthSO : ScriptableObject
{
    public int maxHealth = 100;
    public int currentHealth;

    public UnityEvent<int> OnHealthChanged;

    public Color color;

    private void OnEnable()
    {
        currentHealth = maxHealth; 
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0); 
        OnHealthChanged?.Invoke(currentHealth); 
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); 
        OnHealthChanged?.Invoke(currentHealth); 
    }
}
