using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : Movement
{
    [Header("Jumping")]
    [SerializeField] private float _jumpHeight;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundMask;

    [SerializeField] private float _gravity = -9.81f;

    private Vector3 _velocity;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private bool IsGrounded() { return Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask); }

    public override void Move(Vector2 moveDir)
    {
        Vector3 move = Vector3.zero;

        //Движение
        if(IsGrounded()) move = transform.right * moveDir.x + transform.forward * moveDir.y;
        else move = (transform.right * moveDir.x + transform.forward * moveDir.y) / 2f;
        _controller.Move(move * moveSpeed * Time.deltaTime);

        //Гравитация
        if(IsGrounded() && _velocity.y < 0) _velocity.y = _gravity;

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(!IsGrounded()) return;
        
        _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green; Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
    }
}
