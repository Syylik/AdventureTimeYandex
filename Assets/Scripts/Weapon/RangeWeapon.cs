using UnityEngine;
using UnityEngine.Events;

public class RangeWeapon : MonoBehaviour, IWeapon
{
    [SerializeField, Min(0)] private float _damage = 1f;
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _projectileSpawnPos;

    [SerializeField, Min(0)] private float _shootRate = 2f;
    private float _nextAttackTime;

    internal bool canShoot = true;

    public bool StartAttack()
    {
        if(Time.time >= _nextAttackTime)
        {
            _nextAttackTime = Time.time + 1f / _shootRate;
            SpawnProjectile();
            return true;
        }
        return false;
    }

    public void SpawnProjectile()
    {
        var projectile = Instantiate(_projectile, _projectileSpawnPos.position, _projectile.transform.rotation);
        projectile.Init(_damage, transform.forward);
    }
}
