using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerLook), typeof(Health))]
public class Player : MonoBehaviour
{
    private PlayerMovement _plMove;
    private PlayerLook _plLook;

    private UnityEngine.InputSystem.Input _input;

    private void Awake()
    {
        _plMove = GetComponent<PlayerMovement>();
        _plLook = GetComponent<PlayerLook>();
    }

    private void Start()
    {
        _input = InputSystem.input;

        _input.Player.Jump.performed += context => _plMove.Jump();
    }

    private void Update()
    {
        _plMove.Move(_input.Player.Move.ReadValue<Vector2>());
        _plLook.Look(_input.Player.Look.ReadValue<Vector2>());
    }
}