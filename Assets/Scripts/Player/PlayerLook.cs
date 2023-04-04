using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _sensivity = 100f;
    [SerializeField, Range(0f, 360f)] private float _clampX = 90f;

    private Transform _cam;
    private float _xRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _cam = Camera.main.transform;
    }

    public void Look(Vector2 lookAxis)
    {
        Vector2 look = lookAxis * _sensivity * Time.deltaTime;
        
        _xRot -= look.y;
        _xRot = Mathf.Clamp(_xRot, -_clampX, _clampX);

        _cam.transform.localRotation = Quaternion.Euler(_xRot, 0f, 0f);
        transform.Rotate(Vector3.up * look.x);
    }
}
