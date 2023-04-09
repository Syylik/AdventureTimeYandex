using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeWeapon : MonoBehaviour, IWeapon
{
    [SerializeField, Min(0)] private float _damage;
    [SerializeField, Min(0)] private float _attackRadius;  // Радиус атаки
    [SerializeField, Min(0)] private Transform _attackPoint;

    public LayerMask attackMask;  // Слой, который можно атаковать

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

            var attackObjs = CheckEnemies();
            foreach(var attackObj in attackObjs)
            {
                attackObj.ChangeHealth(-_damage);
            }
        }
    }

    private List<Health> CheckEnemies()
    {
        var cols = Physics.OverlapSphere(_attackPoint.position, _attackRadius, attackMask);

        List<Health> healths = new();
        foreach(var col in cols)
        {
            col.TryGetComponent<Health>(out Health health);
            healths.Add(health);
        }

        return healths;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if(_attackPoint !?? null)
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
    }
}