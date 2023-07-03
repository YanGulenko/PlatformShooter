using UnityEngine;

public class LiftScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _liftRigidBody;

    private void Awake()
    {
        _liftRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _liftRigidBody.velocity = Vector3.up * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lift"))
        {
            _speed *= -1;
        }
    }
}