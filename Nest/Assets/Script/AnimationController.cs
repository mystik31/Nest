using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateAnim
{
    Idle,
    Climb,
    Fall,
    RunLeft,
    RunRight
}

public class AnimationController : MonoBehaviour
{
    private PlayerController _playerController;
    private PlayerMotor _motor;
    private Animator _anim;
    private StateAnim _state;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _anim = GetComponent<Animator>();
        _motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = _motor.GetRigidbody();

        if (_playerController.GetGrounded() && _playerController.GetSpeed() == 1.0)
            _state = StateAnim.RunRight;
        else if (_playerController.GetGrounded() && _playerController.GetSpeed() == -1.0)
            _state = StateAnim.RunLeft;
        else if (!_playerController.GetGrounded() && rb.velocity.y > 0.0)
            _state = StateAnim.Climb;
        else if (!_playerController.GetGrounded() && rb.velocity.y < 0.0)
            _state = StateAnim.Fall;
        else
            _state = StateAnim.Idle;
        Animation();
    }

    private void Animation()
    {
        switch(_state)
        {
            case StateAnim.RunLeft:
                _anim.SetBool("RunLeft", true);
                _anim.SetBool("Idle", false);
                _anim.SetBool("RunRight", false);
                _anim.SetBool("Jump", false);
                _anim.SetInteger("Climb", 0);
                break;
            case StateAnim.RunRight:
                _anim.SetBool("RunLeft", false);
                _anim.SetBool("RunRight", true);
                _anim.SetBool("Idle", false);
                _anim.SetBool("Jump", false);
                _anim.SetInteger("Climb", 0);
                break;
            case StateAnim.Idle:
                _anim.SetBool("RunLeft", false);
                _anim.SetBool("Idle", true);
                _anim.SetBool("RunRight", false);
                _anim.SetBool("Jump", false);
                _anim.SetInteger("Climb", 0);
                break;
            case StateAnim.Climb:
                _anim.SetBool("RunLeft", false);
                _anim.SetBool("Idle", false);
                _anim.SetBool("RunRight", false);
                _anim.SetBool("Jump", true);
                _anim.SetInteger("Climb", 1);
                break;
            case StateAnim.Fall:
                _anim.SetBool("RunLeft", false);
                _anim.SetBool("Idle", false);
                _anim.SetBool("RunRight", false);
                _anim.SetBool("Jump", true);
                _anim.SetInteger("Climb", 2);
                break;
        }
    }
}
