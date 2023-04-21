using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    internal Animator holderAnim;

    [SerializeField, Min(0)] protected float _damage = 1f;
    [SerializeField] protected Transform _attackPoint;

    [SerializeField, Min(0)] protected float _shootRate = 2f;
    protected float _nextAttackTime;

    [SerializeField] private string AttackAnim = "Attack";

    internal bool canAttack = true;
    public virtual bool StartAttack()
    {
        if(Time.time >= _nextAttackTime)
        {
            _nextAttackTime = Time.time + 1f / _shootRate;
            holderAnim.SetTrigger(AttackAnim);
            return true;
        }
        return false;
    }

    public virtual void Attack() { }
}