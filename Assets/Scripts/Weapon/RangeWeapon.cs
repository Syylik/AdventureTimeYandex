using UnityEngine;
using UnityEngine.Events;

public class RangeWeapon : Weapon
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Vector3 _spawnOffset;

    public override void Attack()
    {
        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0f)) + _spawnOffset;
        var projectile = Instantiate(_projectile, spawnPos, _projectile.transform.rotation);
        projectile.Init(_damage, holderAnim.transform.forward);
    }
}
