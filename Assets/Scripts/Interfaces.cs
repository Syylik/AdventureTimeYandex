using UnityEngine;

public interface IMovable
{
    public void Move(Vector2 moveAxis);
}

public interface IWeapon
{
    public void Attack();
}