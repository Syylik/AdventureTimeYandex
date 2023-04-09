using UnityEngine;
using UnityEngine.Events;

public interface IWeapon
{
    public event UnityAction OnAttack;

    public void Attack();
}