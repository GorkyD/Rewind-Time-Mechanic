using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    private enum State
    {
        Jump = 1,
        None = 0,
        Walk = 1,
        Sprint = 2 

    }
    private int _state;
    private int _stateBack;
    private int _stateRight;
    private int _stateLeft;
    private int _stateJump;
    private int _stateForLeft;
    private int _stateForRight;
    private int _stateBackLeft;
    private int _stateBackRight;

    private const string StateAnimationTrigger = "State";
    private static readonly int MainState = Animator.StringToHash(StateAnimationTrigger);

    private const string StateBackAnimationTrigger = "StateBack";
    private static readonly int StateBack = Animator.StringToHash(StateBackAnimationTrigger);

    private const string StateRightAnimationTrigger = "StateRight";
    private static readonly int StateRight = Animator.StringToHash(StateRightAnimationTrigger);

    private const string StateLeftAnimationTrigger = "StateLeft";
    private static readonly int StateLeft = Animator.StringToHash(StateLeftAnimationTrigger);

    private const string StateJumpAnimationTrigger = "StateJump";
    private static readonly int StateJump = Animator.StringToHash(StateJumpAnimationTrigger);

    private const string StateForwardLeftAnimationTrigger = "StateForwardLeft";
    private static readonly int StateForwardLeft = Animator.StringToHash(StateForwardLeftAnimationTrigger);

    private const string StateForwardRightAnimationTrigger = "StateForwardRight";
    private static readonly int StateForwardRight = Animator.StringToHash(StateForwardRightAnimationTrigger);

    private const string StateBackLeftAnimationTrigger = "StateBackLeft";
    private static readonly int StateBackLeft = Animator.StringToHash(StateBackLeftAnimationTrigger);

    private const string StateBackRightAnimationTrigger = "StateBackRight";
    private static readonly int StateBackRight = Animator.StringToHash(StateBackRightAnimationTrigger);


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(KeyCode.W, ref _state);
        }
        else
        {
            _state = (int)State.None ;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Move(KeyCode.S, ref _stateBack);
        }
        else
        {
            _stateBack = (int)State.None;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(KeyCode.D, ref _stateRight);
        }
        else
        {
            _stateRight = (int)State.None;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Move(KeyCode.A, ref _stateLeft);
        }
        else
        { 
            _stateLeft = (int)State.None;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.A))
        {
            Move(KeyCode.W, KeyCode.A, ref _stateForLeft);
        }
        else
        {
            _stateForLeft = (int)State.None;
        }

        if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.D))
        {
            Move(KeyCode.W, KeyCode.D, ref _stateForRight);
        }
        else
        {
            _stateForRight = (int)State.None;
        }

        if (Input.GetKey(KeyCode.S) & Input.GetKey(KeyCode.A))
        {
            Move(KeyCode.S, KeyCode.A, ref _stateBackLeft);
        }
        else
        {
            _stateBackLeft = (int)State.None;
        }

        if (Input.GetKey(KeyCode.S) & Input.GetKey(KeyCode.D))
        {
            Move(KeyCode.S, KeyCode.D, ref _stateBackRight);
        }
        else
        {
            _stateBackRight = (int)State.None;
        }

        _animator.SetInteger(MainState, _state);
        _animator.SetInteger(StateBack, _stateBack);
        _animator.SetInteger(StateRight, _stateRight);
        _animator.SetInteger(StateLeft, _stateLeft);
        _animator.SetInteger(StateJump, _stateJump);
        _animator.SetInteger(StateForwardLeft, _stateForLeft);
        _animator.SetInteger(StateForwardRight, _stateForRight);
        _animator.SetInteger(StateBackLeft, _stateBackLeft);
        _animator.SetInteger(StateBackRight, _stateBackRight);
    }
    

    private void Jump()
    {
        _stateJump = Input.GetKeyDown(KeyCode.Space) ? (int)State.Jump : (int)State.None;
    }

    private void Sprint(ref int state)
    {
        state = Input.GetKey(KeyCode.LeftShift) ? (int)State.Sprint : (int)State.Walk; ;
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

