using UnityEngine;
using UnityEngine.InputSystem;
using Input = UnityEngine.InputSystem.Input;

public class InputSystem : MonoBehaviour
{
    public static Input input { get; private set; }

    public static PlayerInput playerInput { get; private set; }

    public static InputSystem instance { get; private set; }

    private void Awake()
    {
        instance = this;
        input = new Input();
        playerInput = GetComponent<PlayerInput>();
    }

    public void SwitchInputMap(string mapName) => playerInput.SwitchCurrentActionMap(mapName);

    private void OnEnable() => input.Enable();

    private void OnDisable() => input.Disable();
}
