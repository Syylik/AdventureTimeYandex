using UnityEngine;

[AddComponentMenu("States/Enemy")]
public class EnemyAttackState : EnemyState
{
    [SerializeField] private MeleeWeapon _weapon;
    [SerializeField] private float _attackStartRadius;

    public override void Run()
    {
        if(isFinished) return;

        Attack();
    }

    public void Attack()
    {
        if(CheckPlayer()) _weapon.Attack();
    }

    private bool CheckPlayer()
    {
        bool playerInRadius = false;

        playerInRadius = Physics.CheckSphere(author.transform.position, _attackStartRadius, _weapon.attackMask);

        return playerInRadius;
    }
}