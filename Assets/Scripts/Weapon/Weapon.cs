using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Animator _holderAnim;

    [SerializeField, Min(0)] protected float _damage = 1f;
    [SerializeField] protected Transform _attackPoint;

    [SerializeField, Min(0)] protected float _shootRate = 2f;
    protected float _nextAttackTime;

    internal bool canAttack = true;

    public virtual bool StartAttack()
    {
        if(Time.time >= _nextAttackTime)
        {
            _nextAttackTime = Time.time + 1f / _shootRate;
            _holderAnim.SetTrigger("Attack");
            return true;
        }
        return false;
    }

    public virtual void Attack() { }
}
