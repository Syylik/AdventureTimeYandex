using UnityEngine;
using UnityEngine.Events;

public class RangeWeapon : Weapon
{
    [SerializeField] private Projectile _projectile;

    public override void Attack()
    {
        SummonProjectile();
    }

    private Projectile SummonProjectile()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit)) targetPoint = hit.point;
        else targetPoint = ray.GetPoint(75);

        Vector3 direction = targetPoint - _attackPoint.position;
        var rot = new Quaternion(Camera.main.transform.localRotation.x, holderAnim.transform.localRotation.y, 0f, holderAnim.transform.localRotation.w);
        var projectile = Instantiate(_projectile, _attackPoint.position, rot);
        projectile.transform.forward = direction.normalized;
        projectile.Init(_damage, direction);
        return projectile;
    }
}
