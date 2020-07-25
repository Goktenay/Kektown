using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEntity : Entity
{
    [Header("Settings")] 
    [SerializeField] private float _jumpForce;

    [Header("Dependencies")] 
    [SerializeField] private Rigidbody _rigidbody;


    private bool _isGrounded;
    
    // Start is called before the first frame update
    private void Start()
    {
        PlayerCommandBehaviour commandBehaviour = PlayerCommandBehaviour.Instance;
        commandBehaviour.AttackEvent += Attack;
        commandBehaviour.MoveEvent += Move;
        commandBehaviour.InterractEvent += Interract;
        commandBehaviour.JumpEvent += Jump;
    }
    public override void Move(Vector3 dir)
    {
        Debug.Log("Moved");
    }

    public override void Interract()
    {
        Debug.Log("Interracted");
    }

    public override void Jump()
    {

        if (_isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce);
            Debug.Log("Jumped");
        }
    }

    public override void Attack()
    {
        Debug.Log("Attacked");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
