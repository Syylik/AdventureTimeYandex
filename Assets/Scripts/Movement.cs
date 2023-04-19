using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public float moveSpeed;

    public virtual void Move(Vector3 targetPos)
    {
        targetPos = transform.forward;
        Vector3 pos = transform.position;
        pos += targetPos * moveSpeed * Time.deltaTime;
        pos.y = targetPos.y;
        transform.position = pos;
    }
}