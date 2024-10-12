using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState
{
    private PlayerController playerController;

    public WalkState(PlayerController player)
    {
        playerController = player;
    }

    public void Enter()
    {
        playerController.Animator.SetBool("IsRunning", true);
    }

    public void Update()
    {
        if(!playerController.IsGrounded)
        {
            //pasar a jumping
            playerController.StateMachine.TransitionTo(playerController.StateMachine.jumpingState);
        }
        else if (Math.Abs(playerController.CharacterRb.velocity.x) < 0.1f )
        {
            //pasamos a idle
            playerController.StateMachine.TransitionTo(playerController.StateMachine.idleState);
        }
        
    }

    public void Exit()
    {
        playerController.Animator.SetBool("IsRunning", false);
    }
}
