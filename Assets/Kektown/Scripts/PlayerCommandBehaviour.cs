using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommandBehaviour : MonoBehaviour
{
    public static PlayerCommandBehaviour Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public delegate void DirDelegate(Vector3 dir);
    public delegate void VoidDelegate();
    
    public event DirDelegate MoveEvent;
    public event VoidDelegate JumpEvent;
    public event VoidDelegate AttackEvent;
    public event VoidDelegate InterractEvent;
    
    
    // Update is called once per frame
    void Update()
    {
        HandleMovementEvent();
        HandleAttackEvent();
        HandleJumpEvent();
        HandleInterractEvent();
    }

    private void HandleJumpEvent()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpEvent?.Invoke();
        }
    }

    private void HandleInterractEvent()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InterractEvent?.Invoke();
        }
    }

    private void HandleAttackEvent()
    {
        if(Input.GetMouseButtonDown(0))
        {
            AttackEvent?.Invoke();
        }
    }

    private void HandleMovementEvent()
    {
        bool hasMovementInput = false;
        
        Vector3 moveDir = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.W))
        {
            AddToMoveDirVec(Vector3.forward);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            AddToMoveDirVec(Vector3.right);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
           AddToMoveDirVec(Vector3.left);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddToMoveDirVec(Vector3.back);
        }


        if (hasMovementInput)
        {
            moveDir.Normalize();
            MoveEvent?.Invoke(moveDir);
        }
        
        void AddToMoveDirVec(Vector3 vec)
        {
            moveDir += vec;
            hasMovementInput = true;
        }
       
    }
}
