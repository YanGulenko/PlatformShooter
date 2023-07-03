using UnityEngine;

public class EnemyDistanceAttack : MonoBehaviour
{
    [SerializeField] private GameObject _enemyBullet;
    [SerializeField] private Transform _attackEnemyPoint;
    private Quaternion _bulletERotation;
    private EnemiesScript _enemyScript;

    private void Awake()
    {
        _enemyScript = GetComponent<EnemiesScript>();
    }

    public void DistanceAttack()
    {
        if (_enemyScript.IsEnemyRightRotation) { _bulletERotation = Quaternion.Euler(0, 0, 0); }
        else { _bulletERotation = Quaternion.Euler(0, 180, 0); }
        Instantiate(_enemyBullet, _attackEnemyPoint.position, _bulletERotation);
    }
}