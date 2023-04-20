using UnityEngine;

public abstract class EnemyState : ScriptableObject
{
    public bool isFinished { get; protected set; }
    internal Enemy author;   // тот кто вызывает состояния

    public virtual void Enter() { }  // старт, вход состояние (присваивание переменных)

    public abstract void Run();     // работа состояния

    public virtual void Exit() { }  // выход из состояния
}
