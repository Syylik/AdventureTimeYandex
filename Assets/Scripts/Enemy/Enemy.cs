using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyHealth), (typeof(NavMeshAgent)))]
public class Enemy : Movement
{
    [Header("Move")]
    public List<Transform> movePoints;

    public MeleeWeapon weapon;

    internal NavMeshAgent agent;

    [Header("States")]
    [SerializeField] private EnemyState _startState;
    [SerializeField] private EnemyMoveState _moveState;
    [SerializeField] private EnemyState _attackState;

    private EnemyState _currectState;

    internal Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        SetSpeed(moveSpeed);
    }

    private void Start()
    {
        weapon.holderAnim = anim;
        SetState(_startState);
    }

    private void Update()
    {
        if (!_currectState.isFinished) _currectState.Run();
    }
    public void SetState(EnemyState newState)
    {
        if (_currectState != null) _currectState.Exit();

        _currectState = Instantiate(newState);
        _currectState.author = this;
        _currectState.Enter();
    }

    public override void Move(Vector3 targetPos)
    {
        agent.SetDestination(targetPos);
    }

    public void WalkAnim()
    {
        anim.SetBool("isWalk", true);
        anim.SetBool("isRun", false);
        SetSpeed(moveSpeed);
    }

    public void RunAnim()
    {
        anim.SetBool("isWalk", false);
        anim.SetBool("isRun", true);
        SetSpeed(moveSpeed + 4f);
    }

    public void SetSpeed(float speed)
    {
        agent.speed = speed;
    }

    public void SetCanMove() => _moveState.canMove = true;
    
    public void SetCantMove() => _moveState.canMove = false;
}