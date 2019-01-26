using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateAnim
{
    Idle,
    Jump,
    RunLeft,
    RunRight
}

public class AnimationController : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _anim;
    private StateAnim _state;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.GetGrounded() && _playerController.GetSpeed() == 1.0)
            _state = StateAnim.RunRight;
        else if (_playerController.GetGrounded() && _playerController.GetSpeed() == -1.0)
            _state = StateAnim.RunLeft;
        else if (!_playerController.GetGrounded())
            _state = StateAnim.Jump;
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
                break;
            case StateAnim.RunRight:
                _anim.SetBool("RunLeft", false);
                _anim.SetBool("RunRight", true);
                _anim.SetBool("Idle", false);
                _anim.SetBool("Jump", false);
                break;
            case StateAnim.Idle:
                _anim.SetBool("RunLeft", false);
                _anim.SetBool("Idle", true);
                _anim.SetBool("RunRight", false);
                _anim.SetBool("Jump", false);
                break;
            case StateAnim.Jump:
                _anim.SetBool("RunLeft", false);
                _anim.SetBool("Idle", false);
                _anim.SetBool("RunRight", false);
                _anim.SetBool("Jump", true);
                break;
        }
    }
}
