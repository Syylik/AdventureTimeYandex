using System.Drawing;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(menuName = "States/EnemyMove")]
public class EnemyMoveState : EnemyState
{
    [SerializeField] private float _playerFollowRadius;
    [SerializeField] private float _attackStartDistance;
    [SerializeField] private float _minDistance;

    [SerializeField] private EnemyState _attackState;
    private Transform _player;

    private int numberPoint=0;

    public override void Enter()
    {
        _player = FindObjectOfType<Player>().transform;
        
    }
    public override void Run()
    {        
        if (isFinished) return;
        Patroling();
    }

    private void Patroling()
    {
        if (GetDistance(_player.position, author.transform.position) <= _playerFollowRadius)
        {
            author.WalkAnim();
            author.Move(_player.position);
            if (GetDistance(_player.position, author.transform.position) <= _attackStartDistance)
            {
                author.RunAnim();
                author.SetState(_attackState);
            }
        }
        else
        {
            var points = author.movePoints.GetRange(0, author.movePoints.Count);
            author.Move(points[numberPoint].position);
            author.WalkAnim();

            if (Vector3.Distance(points[numberPoint].position, author.transform.position) <= _minDistance) 
            {
                //Debug.Log(_minDistance+" "+ author.agent.remainingDistance + " "+ numberPoint);
                //Debug.Log("!!!"+points[0] + points[1].position);
                numberPoint = (numberPoint + 1) % points.Count;
            }
        }
    }

    private float GetDistance(Vector3 start, Vector3 end) => Vector3.Distance(start, end);
}
