using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _maxTime;
    private float _currentTime;

    private void Awake()
    {
        _currentTime = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health) && _currentTime <= 0)
        {
            health.ChangeHealth(_damage);
            _currentTime = _maxTime;
        }
    }

    private void FixedUpdate()
    {
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
        }
    }
}