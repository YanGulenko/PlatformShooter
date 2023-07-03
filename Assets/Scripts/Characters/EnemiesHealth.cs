using UnityEngine;
using UnityEngine.UI;
using System;
public class EnemiesHealth : MonoBehaviour
{
    [SerializeField] private float _maxEnemieHealth;
    [SerializeField] private int _scoreDrop;
    [SerializeField] private Text _scoreText;
    [SerializeField] private AudioSource _hurtSound;
    [SerializeField] private AudioSource _dieSound;
    private float _currentEnemieHealth;
    private EnemiesAnimator _enemiesAnim;
    public bool IsDeath;

    private void Awake()
    {
        _enemiesAnim = GetComponent<EnemiesAnimator>();
        _currentEnemieHealth = _maxEnemieHealth;
        IsDeath = false;
    }

    private void CheckIsAlive()
    {
        if (_currentEnemieHealth <= 0) 
        {
            _dieSound.Play();
            IsDeath = true;  
            gameObject.layer = 10; 
            _scoreText.text = (Convert.ToInt32(_scoreText.text) + _scoreDrop).ToString(); 
        }
        _enemiesAnim.EnemieDie(IsDeath);
    }

    public void EnemieTakeDamage(float damage)
    {
        _currentEnemieHealth -= damage;
        _enemiesAnim.EnemieHurt();
        _hurtSound.Play();
        CheckIsAlive();
    }   
}