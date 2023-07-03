using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    private Image _healthBar;

    private void Awake()
    {
        _healthBar = GetComponent<Image>();
        _playerHealth.HealthChange += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _playerHealth.HealthChange -= OnHealthChanged;
    }

    private void OnHealthChanged(float value)
    {
        _healthBar.fillAmount = value;
    }
}