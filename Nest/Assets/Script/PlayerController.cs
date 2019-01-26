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

    void Start()
    {
        _motor = GetComponent<PlayerMotor>();
    }
  
    void Update()
    {
        bool Etat = Physics2D.OverlapCircle(_GroundCheck.transform.position, _RadiusCircle, _Layer);
        float x = Input.GetAxis("Horizontal");

        _motor.RunAndJump(x);
        if (Etat && Input.GetButtonDown("Jump"))
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
    }

    private PlayerMotor _motor;
}
