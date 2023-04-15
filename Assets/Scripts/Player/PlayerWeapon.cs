using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private IWeapon _startWeapon;
    [SerializeField] private List<IWeapon> _allWeapons;

    internal IWeapon currentWeapon;

    public UnityEvent OnAttack;

    private void Start()
    {
        OnAttack.AddListener(() => { GetComponent<PlayerMovement>().CameraShake(0.15f, 0.03f); });
        currentWeapon = _startWeapon;
    }

    public void Attack()
    {
        if(currentWeapon != null)
        {
            if(currentWeapon.StartAttack()) OnAttack?.Invoke();
        }
    }
}
