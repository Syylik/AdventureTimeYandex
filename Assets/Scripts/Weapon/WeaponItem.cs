using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public Weapon PickupWeapon(Transform parent)
    {
        var weapon = Instantiate(_weapon, _weapon.transform.position, _weapon.transform.rotation, parent);
        return weapon;
    }
}
