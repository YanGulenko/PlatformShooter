using UnityEngine;
public class EnemiesScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToRevert;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _damage;
    [SerializeField] private AudioSource _strikeSound;
    [SerializeField] private GameObject _target;
    private float _currentTime;
    private float _currentTimeAttack;
    private float _currentState;
    private EnemiesAnimator _anim;
    private EnemiesHealth _health;
    private Rigidbody2D _enemyRigidBody;
    private bool _isPlayerIn;
    private bool _isRevers;
    private const float _idleState = 0;
    private const float _walkState = 1;
    private const float _reversState = 2;
    private const float _combatState = 3;
    public bool IsEnemyRightRotation;

    private void Awake()
    {
        _anim = GetComponent<EnemiesAnimator>();
        _health = GetComponent<EnemiesHealth>();
        _enemyRigidBody = GetComponent<Rigidbody2D>();

        _currentTime = _timeToRevert;
        _currentState = _idleState;
        _currentTimeAttack = _attackDelay;
    }

    private void FixedUpdate()
    {
        if (_isPlayerIn && !_health.IsDeath)
        {
            Combat();
        }
    }

    private void Update()
    {
        if (!_health.IsDeath)
        {
            if (_currentTime <= 0)
            {
                _currentTime = _timeToRevert;
                _currentState = _reversState;
            }
            switch (_currentState)
            {
                case _idleState:
                    _anim.EnemyIdle();
                    _currentTime -= Time.deltaTime;
                    break;
                case _walkState:
                    _anim.EnemyWalk();
                    _enemyRigidBody.velocity = Vector2.right * _speed;
                    break;
                case _reversState:
                    Reverse();
                    _speed *= -1;
                    _currentState = _walkState;
                    break;
                case _combatState:
                    _anim.EnemyIdle();
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StopZone"))
        {
            _currentState = _idleState;
        }
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.ChangeHealth(-5);
        }
        if (collision.gameObject.CompareTag("Player Bullet") && !_isPlayerIn)
        {
            _currentState = _walkState;
            ReverseToTarget();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.ChangeHealth(-1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _currentState = _combatState;
            _isPlayerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _currentState = _idleState;
            _isPlayerIn = false;
        }
    }

    private void Combat()
    {
        ReverseToTarget();
        if (!_health.IsDeath )
        {
            if (_currentTimeAttack <= 0)
            {
                _anim.EnemyAttack();
                _currentTimeAttack = _attackDelay;
            }
            else
            {
                _currentTimeAttack -= Time.deltaTime;
            }
        }
    }

    public void Attack()
    {
        _strikeSound.Play();
        if (_target.GetComponent(typeof(Health)) != null)
        {
            _target.GetComponent<Health>().ChangeHealth(_damage);
        }
    }

    private void Reverse()
    {
        if (_isRevers)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            IsEnemyRightRotation = false;
            _isRevers = false;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            IsEnemyRightRotation = true;
            _isRevers = true;
        }
    }

    private void ReverseToTarget()
    {
        if (_target.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            IsEnemyRightRotation = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            IsEnemyRightRotation = false;
        }
    }
}