using UnityEngine;

public class Projectile : Movement
{
    private float _damage;
    private Vector3 _moveDir;

    public void Init(float damage, Vector3 moveDir)
    {
        _damage = damage;
        _moveDir = moveDir;
        Move(moveDir);
        Destroy(gameObject, 5f);
    }

    public override void Move(Vector3 targetPos)
    {
        GetComponent<Rigidbody>().AddForce(targetPos.normalized * moveSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<Health>(out Health health))
        {
            health.ChangeHealth(-_damage);
            Destroy(gameObject);
        }
        //transform.SetParent(collision.transform);
        Destroy(gameObject, 1f);
    }
}
