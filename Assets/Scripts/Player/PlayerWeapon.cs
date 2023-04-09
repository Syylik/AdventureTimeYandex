using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    internal IWeapon currrentWeapon;

    public void Attack()
    {
        if(currrentWeapon != null) currrentWeapon.Attack();
    }

}
