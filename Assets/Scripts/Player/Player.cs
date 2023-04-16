using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerWeapon))]
public class Player : MonoBehaviour
{
    private PlayerMovement _plMove;
    private PlayerWeapon _plAttack;

    private UnityEngine.InputSystem.Input _input;

    private void Awake()
    {
        _plMove = GetComponent<PlayerMovement>();
        _plAttack = GetComponent<PlayerWeapon>();
    }

    private void Start()
    {
        _input = InputSystem.input;

        _input.Player.Fire.performed += context => _plAttack.StartAttack();
        _input.Player.PreviousWeapon.performed += context => _plAttack.PreviousWeapon();
        _input.Player.NextWeapon.performed += context => _plAttack.NextWeapon();
    }

    private void Update()
    {
        //var a = Mouse.current.scroll.down.ReadValue<float>();
        //Mouse.current.scroll.up
        _plMove.Move(_input.Player.Move.ReadValue<Vector2>());
        _plMove.Look(_input.Player.Look.ReadValue<Vector2>());
        _plMove.SetJump(_input.Player.Jump.IsPressed(), _input.Player.Jump.WasReleasedThisFrame());
    }
}