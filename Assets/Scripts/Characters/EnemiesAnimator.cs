using UnityEngine;
[RequireComponent(typeof(Animator))]
public class EnemiesAnimator : MonoBehaviour
{
    private Animator _enemiesAnim;

    private void Awake()
    {
        _enemiesAnim = GetComponent<Animator>();
    }

    public void EnemieDie(bool isDie)
    {
        _enemiesAnim.SetBool("Death", isDie);
    }

    public void EnemieHurt()
    {
        _enemiesAnim.SetTrigger("Hurt");
    }

    public void EnemieDead()
    {
        EnemieDie(false);
    }

    public void EnemyAttack()
    {
        _enemiesAnim.SetTrigger("Attack");
    }

    public void EnemyWalk()
    {
        _enemiesAnim.SetInteger("AnimState", 2);
    }

    public void EnemyIdle()
    {
        _enemiesAnim.SetInteger("AnimState", 0);
    }
}