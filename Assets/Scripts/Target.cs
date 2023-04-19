using UnityEngine;

public class Target : Health
{
    public override void ChangeHealth(float value)
    {
        Die();
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}
