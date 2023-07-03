using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    public event Action<float> HealthChange;
    public event Action<bool> IsHealthDamage;

    private void Awake()
    {  
        _currentHealth = _maxHealth;
    }

    private void CheckHealth()
    {
        if (_currentHealth <= 0) { Death();  }
        if (_currentHealth > _maxHealth) { _currentHealth = _maxHealth; }
    }

    public void ChangeHealth(float value)  // теперь одна функция отвечает и за урон и за отхил
    {
        _currentHealth += value;             
        HealthChange?.Invoke(_currentHealth/ _maxHealth);
        CheckHealth();
        if (value < 0) 
        { 
            IsHealthDamage?.Invoke(true);
        }
        else
        {
            IsHealthDamage?.Invoke(false);
        }
    }

    private void Death()
    {
        GetComponent<PlayerInput>().enabled = false;
        LoadDeathScene();
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

    private void LoadDeathScene()
    {
        SceneManager.LoadScene(3);
    }
}