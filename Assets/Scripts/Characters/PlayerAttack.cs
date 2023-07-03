using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimator _playerAnimator;
    private PlayerMovement _playerMovement;
    private Quaternion _bulletRotation;
    [SerializeField] private AudioSource _attackSound;
    [SerializeField] private AudioSource _failAttackSound;
    [SerializeField] private GameObject _playerBullet;
    [SerializeField] private float _timeDelayAttack;
    [SerializeField] private int _maxBullets;
    [SerializeField] private Text _bulletsText;
    [SerializeField] private GameObject _rechargeImage;
    [SerializeField] private float _rechargeTime;
    private int _bullets;
    private float _currentTime;
    public Transform AttackPoint;
    public bool IsAttack;
    public bool AttackIsReady;

    private void Awake()
    {
        _bullets = _maxBullets;
        AttackIsReady = true;
        _currentTime = _rechargeTime;
        _playerAnimator = GetComponent<PlayerAnimator>();    
        _playerMovement = GetComponent<PlayerMovement>();      
    }

    private void FixedUpdate()
    {
        BulletAndRecharge();
    }

    public void Attack()
    {
        IsAttack = true;
        Invoke("AttakDelay", _timeDelayAttack);
        _playerAnimator.Attack(); //запуск анимации атаки
        _attackSound.Play();
        if (_playerMovement.PlayerRightRotation) { _bulletRotation = Quaternion.Euler(0 , 0 , 0); }
        else { _bulletRotation = Quaternion.Euler(0, 180, 0); }
        Instantiate(_playerBullet, AttackPoint.position, _bulletRotation);
        --_bullets;
    }

    private void AttakDelay()
    {
        IsAttack = false;
    }

    private void BulletAndRecharge()
    {
        _bulletsText.text = _bullets.ToString();
        if (_bullets == 0)
        {    
            if (_currentTime <= 0)
            {
                AttackIsReady = true;
                _currentTime = _rechargeTime;
                _rechargeImage.SetActive(false);
                _bullets = _maxBullets;
            }
            else
            {
                AttackIsReady = false;
                _currentTime -= Time.fixedDeltaTime;
                _rechargeImage.SetActive(true);
            }
        }
    }

    public void FailAttack()
    {
        _failAttackSound.Play();
    }
}