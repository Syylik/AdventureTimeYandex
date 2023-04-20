using UnityEngine;

public class Dummy : Health
{
    //private new GameObject dieEffect;
    private Animator _anim;

    private void Awake() => _anim = GetComponent<Animator>();

    public override void ChangeHealth(float value)
    {
        Debug.Log(value);
        _anim.SetTrigger("Damage");
    }
}
