using UnityEngine;

[CreateAssetMenu(menuName = "States/EnemyAttack")]
public class EnemyAttackState : EnemyState
{
    [SerializeField] private MeleeWeapon _weapon;
    [SerializeField] private float _attackEndRadius;

    [SerializeField] private EnemyState _moveState;

    public override void Run()
    {
        if(isFinished) return;

        Attack();
    }

    public void Attack()
    {
        if(CheckPlayer()) _weapon.StartAttack();
        else author.SetState(_moveState);
    }

    private bool CheckPlayer()
    {
        bool playerInRadius = false;

        playerInRadius = Physics.CheckSphere(author.transform.position, _attackEndRadius, _weapon.attackMask);

        return playerInRadius;
    }
}