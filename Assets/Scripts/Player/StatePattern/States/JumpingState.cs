using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : IState
{
    private PlayerController playerController;

    public JumpingState(PlayerController player)
    {
        playerController = player;
    }

    public void Enter()
    {
        playerController.Animator.SetBool("IsJumping", true);
    }

    public void Update()
    {
        if(playerController.IsGrounded)
        {
            if (Math.Abs(playerController.CharacterRb.velocity.x) > 0.1f )
            {
                // Walk
                playerController.StateMachine.TransitionTo(playerController.StateMachine.walkState);
            }
            else
            {
                // Idle
                playerController.StateMachine.TransitionTo(playerController.StateMachine.idleState);
            }
            
        }
    }

    public void Exit()
    {
        playerController.Animator.SetBool("IsJumping", false);
    }
}
