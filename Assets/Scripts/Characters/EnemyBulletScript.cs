using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private Rigidbody2D _enemyBulletRigidBody;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDamage;

    private void Awake()
    {
        _enemyBulletRigidBody = GetComponent<Rigidbody2D>();
        _enemyBulletRigidBody.AddForce(transform.right * _bulletSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 4);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().ChangeHealth(_bulletDamage);
        }
        Destroy(gameObject);
    }
}