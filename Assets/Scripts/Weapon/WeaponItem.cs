using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public Weapon PickupWeapon()
    {
        Destroy(gameObject);
        return _weapon;
    }
}
