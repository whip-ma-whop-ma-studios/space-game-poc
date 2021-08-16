using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int _currentHealth;
    [SerializeField]
    public int _maxHealth;
    [SerializeField]
    public HealthBar _healthBar;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    public void UpdateHealth(int health)
    {
        _currentHealth += health;
        _healthBar.SetHealth(_currentHealth);
    }
}
