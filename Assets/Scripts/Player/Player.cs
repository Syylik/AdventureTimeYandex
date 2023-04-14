using UnityEngine;

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

        //_plAttack.currentWeapon.OnAttack += _plAnim.AttackAnim();
        _input.Player.Fire.performed += context => _plAttack.Attack();
    }

    private void Update()
    {
        _plMove.Move(_input.Player.Move.ReadValue<Vector2>());
        _plMove.Look(_input.Player.Look.ReadValue<Vector2>());
        _plMove.SetJump(_input.Player.Jump.IsPressed(), _input.Player.Jump.WasReleasedThisFrame());
    }
}