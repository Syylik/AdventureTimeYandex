using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _anim;

    private void Awake() => _anim = GetComponent<Animator>();

    public void OpenDoor() => _anim.SetTrigger("Open");

    public void CloseDoor() => _anim.SetTrigger("Close");
}
