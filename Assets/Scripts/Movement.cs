using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public float moveSpeed;

    public virtual void Move(Vector2 moveDir)
    {
        Vector3 move = transform.position;
        move += transform.right * moveDir.x + transform.forward * moveDir.y;
        transform.position = move * moveSpeed * Time.deltaTime;
    }

    public virtual void Move(Vector3 targetPos)
    {
        targetPos.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);    
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetPos - transform.position), 120f * Time.deltaTime);    
    }
}
