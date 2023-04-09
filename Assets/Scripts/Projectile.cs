using UnityEngine;

public class Projectile : Movement
{
    private float _damage;
    private Vector3 _moveDir;

    public void Init(float damage, Vector3 moveDir)
    {
        _damage = damage;
        _moveDir = moveDir;
    }

    private void Update()
    {
        Move(_moveDir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<EnemyHealth>(out EnemyHealth health))
        {
            health.ChangeHealth(-_damage);
        }
    }
}
