using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private MovementCharacteristics _characteristics;

    private float _vertical, _horizontal, _run;

    private const string Str_Vertical = "Vertical";
    private const string Str_Horizontal = "Horizontal";
    private const string Str_Run = "Run";
    private const string Str_Jump = "Jump";

    private const float _distanceOffsetCamera = 5f;

    private CharacterController _controller;

    private Vector3 _globalDirection;
    private Quaternion _lookRotation;

    private Vector3 TargetRotate => _camera.forward * _distanceOffsetCamera;
    private bool Idle => float.Equals(_horizontal == 0.0f,_vertical == 0.0f);

    private void Start()
    {
        _controller = GetComponent<CharacterController>();

        Cursor.visible = _characteristics.VisibleCursor;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        if (_controller.isGrounded)
        {
            _horizontal = Input.GetAxis(Str_Horizontal);
            _vertical = Input.GetAxis(Str_Vertical);
            _run = Input.GetAxis(Str_Run);

            _globalDirection = transform.TransformDirection(_horizontal, 0, _vertical).normalized;
            Jump();
        }

        _globalDirection.y -= _characteristics.Gravity * Time.deltaTime;

        float speed = _run * _characteristics.RunSpeed + _characteristics.MovementSpeed;
        Vector3 _localDirection = _globalDirection * speed * Time.deltaTime;

        _localDirection.y = _globalDirection.y;

        _controller.Move(_localDirection);
    }

    private void Rotate()
    {
        if (Idle) return;

        Vector3 target = TargetRotate;
        target.y = 0;

        _lookRotation = Quaternion.LookRotation(target);

        float speed = _characteristics.AngularSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, speed);
    }

    private void Jump()
    {
        if (Input.GetButtonDown(Str_Jump))
        {
            _globalDirection.y += _characteristics.JumpForce;
        }
    }
}