using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeWeapon : Weapon
{
    [SerializeField] private Vector3 _attackBox;
    public LayerMask attackMask;  // Слой, который можно атаковать

    public override void Attack()
    {
        var attackObjs = CheckEnemies();
        foreach(var attackObj in attackObjs)
        {
            attackObj.ChangeHealth(-_damage);
        }
    }

    private List<Health> CheckEnemies()
    {
        //var cols = Physics.OverlapSphere(_attackPoint.position, _attackRadius, attackMask);
        var cols = Physics.OverlapBox(_attackPoint.position, _attackBox, Quaternion.identity, attackMask);
        
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
        Gizmos.DrawWireCube(_attackPoint.position, _attackBox);
    }
}