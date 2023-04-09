using UnityEngine;
using UnityEngine.Events;

public class RangeWeapon : MonoBehaviour, IWeapon
{
    [SerializeField, Min(0)] private float _damage;
    [SerializeField] private float _projectile;

    [SerializeField, Min(0)] private float _attackColdown; // Задержка между атаками (в сек)
    private float _coldownTimeLeft;

    public event UnityAction OnAttack;

    private void Update() => _coldownTimeLeft -= Time.deltaTime;

    public void Attack()
    {
        if(_coldownTimeLeft <= 0)
        {
            OnAttack?.Invoke();
            _coldownTimeLeft = _attackColdown;
        }
    }

    private void SpawnProjectile()
    {

    }
}
