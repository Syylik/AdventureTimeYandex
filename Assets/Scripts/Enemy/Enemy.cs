using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyHealth),(typeof(NavMeshAgent)))]
public class Enemy : Movement
{
    [Header("Move")]
    public List<Transform> movePoints;

    internal NavMeshAgent agent;

    [Header("States")]
    [SerializeField] private EnemyState _startState;
    [SerializeField] private EnemyState _moveState;
    [SerializeField] private EnemyState _attackState;

    private EnemyState _currectState;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SetState(_startState);
    }

    private void Update()
    {
        if(!_currectState.isFinished) _currectState.Run();
    }

    public void SetState(EnemyState newState)
    {
        if(_currectState != null) _currectState.Exit();

        _currectState = Instantiate(newState);
        _currectState.author = this;
        _currectState.Enter();
    }

    public override void Move(Vector3 targetPos)
    {
        agent.SetDestination(targetPos);
    }
}
