using UnityEngine;
using UnityEngine.Events;

public class RangeWeapon : Weapon
{
    [SerializeField] private Projectile _projectile;

    public override void Attack()
    {
        var projectile = Instantiate(_projectile, _attackPoint.position, _projectile.transform.rotation);
        projectile.Init(_damage, transform.forward);
    }
}
