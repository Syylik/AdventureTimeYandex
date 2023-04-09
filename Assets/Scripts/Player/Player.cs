using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerLook), typeof(PlayerWeapon))]
public class Player : MonoBehaviour
{
    private PlayerMovement _plMove;
    private PlayerWeapon _plAttack;
    private PlayerLook _plLook;

    private UnityEngine.InputSystem.Input _input;

    private void Awake()
    {
        _plMove = GetComponent<PlayerMovement>();
        _plAttack = GetComponent<PlayerWeapon>();
        _plLook = GetComponent<PlayerLook>();
    }

    private void Start()
    {
        _input = InputSystem.input;

        //_plAttack.currrentWeapon.OnAttack += _plAnim.Attack();
        _input.Player.Jump.performed += context => _plMove.Jump();
        _input.Player.Fire.performed += context => _plAttack.Attack();
    }

    private void Update()
    {
        _plMove.Move(_input.Player.Move.ReadValue<Vector2>());
        _plLook.Look(_input.Player.Look.ReadValue<Vector2>());
    }
}