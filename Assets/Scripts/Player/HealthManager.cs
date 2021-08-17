using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private int _currentHealth;
    [SerializeField]
    public int _maxHealth;
    [SerializeField]
    public HealthBar _healthBar;

    public void UpdateHealth(int health)
    {
        _currentHealth += health;
        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Debug.Log("Player died");
            // TODO Do something
        }
        _healthBar.SetHealth(_currentHealth);
    }

    public void SetMaxHealth()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetHealth(_currentHealth);
    }
}
