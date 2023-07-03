using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    private Rigidbody2D _playerBulletRigidBody;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDamage;

    private void Awake()
    {
        _playerBulletRigidBody = GetComponent<Rigidbody2D>();
        _playerBulletRigidBody.AddForce(transform.right * _bulletSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 0.7f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemiesHealth>().EnemieTakeDamage(_bulletDamage);
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        Destroy(gameObject);
    }
}