using UnityEngine;

public class HealthKit : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private float _value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerHealth.ChangeHealth(_value);
            Destroy(gameObject);
        }      
    }
}