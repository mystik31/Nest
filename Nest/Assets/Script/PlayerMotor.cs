using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(PlayerController))]

public class PlayerMotor : MonoBehaviour
{
    void Start()
    {
        _velocity = Vector2.zero;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PerformRunAndJump();
    }

    public void RunAndJump(float x)
    {
        _rb.velocity = new Vector2(x * _MaxSpeed * Time.deltaTime, _rb.velocity.y);
    }

    private void PerformRunAndJump()
    {
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }
        else if (_rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (5f - 1) * Time.deltaTime;
        }
    }

    private Vector2 _velocity;
    private Rigidbody2D _rb;
    [SerializeField] private float _MaxSpeed;
    [SerializeField] private float _MaxSpeedJump;
}
