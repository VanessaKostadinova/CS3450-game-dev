using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Camera cam;
    private float _speed;
    private Vector2 _mouseInput;
    private Vector2 _keyboardInput;
    public CharacterController characterController;
    public GameObject body;
    public bool _grounded;
    private const float Gravity = -9.81f;
    private float _verticalVelocity;
    private bool _jump;
    private const float TerminalVelocity = -200f;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 5f;
        _keyboardInput = new Vector2(0f, 0f);
        _mouseInput = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {/*
        _grounded = Physics.CheckSphere(body.transform.position, 0.75f, LayerMask.GetMask("Ground"), QueryTriggerInteraction.Ignore);

        //_grounded = characterController.isGrounded;
        
        if (_grounded)
        {
            if (!_jump)
            {
                //_verticalVelocity = _gravity * Time.deltaTime;
                _verticalVelocity = 0f;
            }
            else
            {
                _verticalVelocity += 100f * Time.deltaTime;
                _jump = false;
            }
        }
        else
        {
            _verticalVelocity += _gravity * Time.deltaTime;
        }

        //Rotate direction relative to north and apply speed
        var direction = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * new Vector3(_keyboardInput.x, 0f, _keyboardInput.y) * (_speed * Time.deltaTime);
        direction.y = _verticalVelocity;
        
        Debug.Log(_verticalVelocity);

        characterController.Move(direction);
        
        //_keyboardInput = new Vector2(0f, 0f);
        //transform.Translate(direction * (_speed * Time.deltaTime));*/
    }

    private void FixedUpdate()
    {
        //_grounded = Physics.CheckSphere(body.transform.position, 0.75f, LayerMask.GetMask("Ground"), QueryTriggerInteraction.Ignore);

        _grounded = characterController.isGrounded;
        
        if (_grounded)
        {
            if (!_jump)
            {
                _verticalVelocity = Gravity * Time.deltaTime;
                //_verticalVelocity = 0f;
            }
            else
            {
                _verticalVelocity += 100f * Time.fixedDeltaTime;
                _jump = false;
            }
        }
        else
        {
            if (_verticalVelocity > TerminalVelocity)
            {
                _verticalVelocity += Gravity * Time.fixedDeltaTime;
            }
        }

        //Rotate direction relative to north and apply speed
        var direction = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * new Vector3(_keyboardInput.x, 0f, _keyboardInput.y) * (_speed * Time.fixedDeltaTime);
        direction.y = _verticalVelocity;
        
        Debug.Log(_verticalVelocity);

        characterController.Move(direction);
        
        //_keyboardInput = new Vector2(0f, 0f);
        //transform.Translate(direction * (_speed * Time.deltaTime));
    }

    public void Move(InputAction.CallbackContext c)
    {
        _keyboardInput = c.ReadValue<Vector2>();
    }

    public void Look(InputAction.CallbackContext c)
    {
        _mouseInput = c.ReadValue<Vector2>();
        transform.Rotate(Quaternion.Euler(0f, _mouseInput.x * Time.deltaTime, 0f).eulerAngles);
    }

    public void Jump(InputAction.CallbackContext c)
    {
        if (_grounded)
        {
            _jump = true;
        }

        Debug.Log("jumping");
    }

    public void Sprint(InputAction.CallbackContext c)
    {
        
    }
}
