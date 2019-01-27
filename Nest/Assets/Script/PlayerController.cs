using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    [Range(1, 20)]
    public float jumpVelocity, leftVelocity;

    [SerializeField] private GameObject _GroundCheck;
    [SerializeField] private LayerMask _Layer;
    [SerializeField] private float _RadiusCircle;

    private bool _grounded;
    private PlayerMotor _motor;
    private float _speed;

    void Start()
    {
        _motor = GetComponent<PlayerMotor>();
        _speed = 0;
    }

     void Update()
     {
        _grounded = Physics2D.OverlapCircle(_GroundCheck.transform.position, _RadiusCircle, _Layer);
        _speed = Input.GetAxis("Horizontal");

         _motor.RunAndJump(_speed);
         if (_grounded && Input.GetButtonDown("Jump"))
             GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
     }

    public bool GetGrounded()
    {
        return (_grounded);
    }

    public float GetSpeed()
    {
        return _speed;
    }
}
