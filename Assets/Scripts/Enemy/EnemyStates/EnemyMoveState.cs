using UnityEngine;

[AddComponentMenu("States/Enemy")]
public class EnemyMoveState : EnemyState
{
    [SerializeField] private float _playerFollowRadius;
    [SerializeField] private float _attackStartDistance;

    [SerializeField] private EnemyState _attackState;

    private Transform _player;

    public void Init(Transform player)
    {
        _player = player;
    }

    public override void Run()
    {
        if(isFinished) return;
        Patroling();
    }

    private void Patroling()
    {
        if(GetDistance(_player.position, author.transform.position) <= _playerFollowRadius)
        {   
            author.Move(_player.position);
            if(GetDistance(_player.position, author.transform.position) <= _attackStartDistance)
            {
                author.SetState(_attackState);
            }
        }
        else
        {
            // Движение по точкам
        }
    }

    private float GetDistance(Vector3 start, Vector3 end) => Vector3.SqrMagnitude(start - end);
}
