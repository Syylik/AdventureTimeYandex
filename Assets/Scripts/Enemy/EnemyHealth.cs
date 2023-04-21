using UnityEngine;

public class EnemyHealth : Health
{
    public override void Die()
    {
        base.Die();
        if(TryGetComponent<Animator>(out Animator anim))
        {
            anim.SetTrigger("Die");
            Destroy(gameObject, 4f);
        }
        else Destroy(gameObject);
    }
}