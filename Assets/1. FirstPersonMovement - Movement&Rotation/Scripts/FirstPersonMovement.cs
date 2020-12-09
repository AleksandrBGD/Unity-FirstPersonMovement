using UnityEngine;
using BGD.FirsPersonMovement;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private MovementCharacteristics _characteristics;
    [SerializeField] private PoolKeyInput _input;

    private float _horizontal, _vertical;
    private float _mouseX, _mouseY;

    private float _rotX, _rotY;// Vector2

    private Vector3 _dir;


    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();

        Vector3 rot = transform.localRotation.eulerAngles;
        _rotX = rot.x;
        _rotY = rot.y;

        Cursor.visible = _characteristics.VisibleCursor;
    }


    private void Update()
    {
        Movement();
        Rotate();
    }

    private void Movement()
    {
        if(_controller.isGrounded)
        {
            _horizontal = Input.GetAxis(_input.Horizontal);
            _vertical = Input.GetAxis(_input.Vertical);

            _dir = transform.TransformDirection(_horizontal, 0, _vertical).normalized;

        }

        _dir.y -= _characteristics.Gravity * Time.deltaTime;

        _controller.Move(_dir * _characteristics.MovementSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        _mouseX = Input.GetAxis(_input.MouseX);
        _mouseY = Input.GetAxis(_input.MouseY);

        _rotX -= _characteristics.AngularSpeed * _mouseY * Time.deltaTime;
        _rotY += _characteristics.AngularSpeed * _mouseX * Time.deltaTime;

        _rotX = Mathf.Clamp(_rotX, -_characteristics.ClampAngleX, _characteristics.ClampAngleX);

        Quaternion rotY = Quaternion.Euler(0, _rotY, 0);
        Quaternion localRotX = Quaternion.Euler(_rotX, 0, 0);

        transform.rotation = rotY;
        _camera.localRotation = localRotX;

    }
}
