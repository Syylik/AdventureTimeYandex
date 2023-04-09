using UnityEngine;

public abstract class EnemyState : ScriptableObject
{
    public bool isFinished { get; protected set; }
    internal Enemy author;   // ��� ��� �������� ���������

    public void Enter() { }  // �����, ���� ��������� (������������ ����������)

    public abstract void Run();     // ������ ���������

    public virtual void Exit() { }  // ����� �� ���������
}
