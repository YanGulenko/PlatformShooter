using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource _playerHurt;
    [SerializeField] private AudioSource _playerCollectHealthkit;
    [SerializeField] private Health _playerHealth;

    private void Awake()
    {
        _playerHealth.IsHealthDamage += OnHealthBeChanged;
    }

    private void OnDestroy()
    {
        _playerHealth.IsHealthDamage -= OnHealthBeChanged;
    }

    private void OnHealthBeChanged(bool isDamage)
    {
        if (isDamage) { _playerHurt.Play();  }
        else { _playerCollectHealthkit.Play(); }
    }
}