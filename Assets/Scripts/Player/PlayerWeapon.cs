using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Weapon _startWeapon;
    [SerializeField] private List<Weapon> _allWeapons;

    [SerializeField] private Transform _weaponParent;

    internal Weapon currentWeapon;
    private int _currentWeaponIndex;

    internal Animator anim;

    private bool _isChangingWeapon = false;

    public UnityEvent OnAttack;

    private void Start()
    {
        foreach(var weapon in _allWeapons) weapon.holderAnim = anim;

        OnAttack.AddListener(() => AttackShake());
        currentWeapon = _startWeapon;
        _currentWeaponIndex = _allWeapons.IndexOf(currentWeapon);

        SetWeapon();
    }

    private void AttackShake()
    {
        if(currentWeapon is MeleeWeapon)
        GetComponent<PlayerMovement>().CameraShake(0.15f, 0.03f);
    }
     
    public void StartAttack()
    {
        if(currentWeapon != null)
        {
            if(currentWeapon.StartAttack())
            {
                OnAttack?.Invoke();
                currentWeapon.StartAttack();
            }
        }
    }

    public void PreviousWeapon() => SelectWeapon(-1);

    public void NextWeapon() => SelectWeapon(1);

    public void SelectWeapon(int index)
    {
        if(_allWeapons.Count <= 1 || _isChangingWeapon) return; 
        int newWeaponIndex = _currentWeaponIndex + index;
        if(newWeaponIndex > _allWeapons.Count -1) newWeaponIndex = 0;
        else if(newWeaponIndex < 0) newWeaponIndex = _allWeapons.Count -1;

        _currentWeaponIndex = newWeaponIndex;

        _isChangingWeapon = true;
        anim.SetTrigger("Drop");
    }

    public void SetWeapon()
    {
        currentWeapon = _allWeapons[_currentWeaponIndex];
        foreach(var weapon in _allWeapons) weapon.gameObject.SetActive(false);
        currentWeapon.gameObject.SetActive(true);
    }

    public void EndWeaponChange() => _isChangingWeapon = false; // для Animator

    public void Attack() { if(currentWeapon != null) currentWeapon.Attack(); } // для Animator

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<WeaponItem>(out WeaponItem item))
        {
            _allWeapons.Add(item.PickupWeapon(_weaponParent));
        }
    }
}