using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeWeapon : Weapon
{
    [SerializeField] private Vector3 _attackBox;
    [SerializeField] private Vector3 _attackOffset;
    public LayerMask attackMask;  // Слой, который можно атаковать

    [SerializeField] private GameObject _attackEffect;
    [SerializeField] private Transform _originEffectRot;

    public override void Attack()
    {
        var attackObjs = CheckEnemies();
        SpawnEffect();
        foreach(var attackObj in attackObjs)
        {
            attackObj.ChangeHealth(-_damage);
        }
    }

    private List<Health> CheckEnemies()
    {
        //var cols = Physics.OverlapSphere(_attackPoint.position, _attackRadius, attackMask);
        var cols = Physics.OverlapBox(_attackPoint.position + _attackOffset, _attackBox, transform.rotation, attackMask);
        
        List<Health> healths = new();
        foreach(var col in cols)
        {
            col.TryGetComponent<Health>(out Health health);
            healths.Add(health);
        }

        return healths;
    }

    private void SpawnEffect()
    {
        if(_attackEffect != null)
        Instantiate(_attackEffect, _attackPoint.position, _originEffectRot.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if(_attackPoint !?? null)
        Gizmos.DrawWireCube(_attackPoint.position + _attackOffset, _attackBox);
    }
}