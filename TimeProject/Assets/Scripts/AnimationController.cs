using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private int _state;
    private int _stateBack;
    private int _stateRight;
    private int _stateLeft;
    private int _stateJump;
    private int _stateForLeft;
    private int _stateForRight;
    private int _stateBackLeft;
    private int _stateBackRight;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            Move(KeyCode.W, ref _state);
        else
            _state = 0;

        if (Input.GetKey(KeyCode.S))
            Move(KeyCode.S, ref _stateBack);
        else
            _stateBack = 0;

        if (Input.GetKey(KeyCode.D))
            Move(KeyCode.D, ref _stateRight);
        else
            _stateRight = 0;

        if (Input.GetKey(KeyCode.A))
            Move(KeyCode.A, ref _stateLeft);
        else
            _stateLeft = 0;

        if (Input.GetKey(KeyCode.Space))
            Jump();

        if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.A))
            Move(KeyCode.W, KeyCode.A, ref _stateForLeft);
        else
            _stateForLeft = 0;

        if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.D))
            Move(KeyCode.W, KeyCode.D, ref _stateForRight);
        else
            _stateForRight = 0;

        if (Input.GetKey(KeyCode.S) & Input.GetKey(KeyCode.A))
            Move(KeyCode.S, KeyCode.A, ref _stateBackLeft);
        else
            _stateBackLeft = 0;

        if (Input.GetKey(KeyCode.S) & Input.GetKey(KeyCode.D))
            Move(KeyCode.S, KeyCode.D, ref _stateBackRight);
        else
            _stateBackRight = 0;

        animator.SetInteger("State", _state);
        animator.SetInteger("StateBack", _stateBack);
        animator.SetInteger("StateRight", _stateRight);
        animator.SetInteger("StateLeft", _stateLeft);
        animator.SetInteger("StateJump", _stateJump);
        animator.SetInteger("StateForwardLeft", _stateForLeft);
        animator.SetInteger("StateForwardRight", _stateForRight);
        animator.SetInteger("StateBackLeft", _stateBackLeft);
        animator.SetInteger("StateBackRight", _stateBackRight);
    }
    


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _stateJump = 1;
        }
        else
        {
            _stateJump = 0;
        }
    } 
    private void Sprint(ref int state)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            state = 2;
        }
        else
        {
            state = 1;
        }
    }
    private void Move(KeyCode key,ref int state)
    {
        Jump();
        if (Input.GetKey(key))
        {
            Sprint(ref state);
        }
    }
    private void Move(KeyCode key, KeyCode key1, ref int state)
    {
        Jump();
        if (Input.GetKey(key) & Input.GetKey(key1))
        {
            Sprint(ref state);
        }
    }
}

