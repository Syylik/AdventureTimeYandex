using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Weapon _startWeapon;
    [SerializeField] private List<Weapon> _allWeapons;

    internal Weapon currentWeapon;
    private int _currentWeaponIndex;

    private Animator _anim;

    public UnityEvent OnAttack;

    private void Start()
    {
        OnAttack.AddListener(() => { GetComponent<PlayerMovement>().CameraShake(0.15f, 0.03f); });
        currentWeapon = _startWeapon;
        _currentWeaponIndex = _allWeapons.IndexOf(currentWeapon);
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
        if(_allWeapons.Count < 0) return; 
        int newWeaponIndex = _currentWeaponIndex + index;
        if(newWeaponIndex > _allWeapons.Count) newWeaponIndex = _allWeapons.Count;
        else if(newWeaponIndex < 0) newWeaponIndex = 0;

        _currentWeaponIndex = newWeaponIndex;

        
        currentWeapon = _allWeapons[newWeaponIndex];
        _anim.SetTrigger("Drop");
    }

    public void SetWeapon()
    {
        foreach(var weapon in _allWeapons) weapon.gameObject.SetActive(false);
        currentWeapon.gameObject.SetActive(true);
    }

    public void Attack() { if(currentWeapon != null) currentWeapon.Attack(); } // для Animator
}