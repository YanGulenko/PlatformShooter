using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _playerAnim;
    private Health _playerHealth;

    private void Awake()
    {
        _playerAnim = GetComponent<Animator>();
        _playerHealth = GetComponent<Health>();
        _playerHealth.IsHealthDamage += Hurt;
    }

    private void OnDestroy()
    {
        _playerHealth.IsHealthDamage -= Hurt;
    }

    public void Run()
    {
        _playerAnim.SetBool("isRun", true);
    }

    public void StopRun()
    {
        _playerAnim.SetBool("isRun", false);
    }

    public void IsGrounded(bool isIt)
    {
        _playerAnim.SetBool("isGrounded", isIt);
    }

    public void SpeedCheck(float speed)
    {
        _playerAnim.SetFloat("vSpeed", speed);
    }

    private void Hurt(bool isHurt)
    {
        if (isHurt)
        {
            _playerAnim.SetTrigger("Hurt");
        }
    }

    public void Attack()
    {
        _playerAnim.SetTrigger("Attack");
    }
}