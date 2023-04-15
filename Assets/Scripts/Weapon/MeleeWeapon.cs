using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeWeapon : MonoBehaviour, IWeapon
{
    [SerializeField, Min(0)] private float _damage = 1f;
    [SerializeField, Min(0)] private float _attackRadius = 1.2f;  // ������ �����
    [SerializeField, Min(0)] private Transform _attackPoint;

    public LayerMask attackMask;  // ����, ������� ����� ���������

    [SerializeField, Min(0)] private float _attackRate = 1f; // ���-�� ��������� ������ (� 1 ���)
    private float _nextAttackTime;

    internal bool canAttack = true;

    private Animator _playerAnim;

    /// <summary>
    /// �������� ������
    /// </summary>
    /// <returns>���������� �������� �� �����</returns>
    public bool StartAttack()
    {
        if(Time.time >= _nextAttackTime)
        {
            _nextAttackTime = Time.time + 1f / _attackRate;
            return true;
        }
        return false;
    }

    public void Attack()
    {
        var attackObjs = CheckEnemies();
        foreach(var attackObj in attackObjs)
        {
            attackObj.ChangeHealth(-_damage);
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