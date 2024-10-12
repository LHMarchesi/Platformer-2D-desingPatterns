using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerController playerController;

    public IdleState(PlayerController player)
    {
        playerController = player;
    }

    public void Enter()
    {

    }

    public void Update()
    {
        if (!playerController.IsGrounded)
        {
            // Jump
            playerController.StateMachine.TransitionTo(playerController.StateMachine.jumpingState);
        }
        else if (Math.Abs(playerController.CharacterRb.velocity.x) > 0.1f)
        {
           // Walk
            playerController.StateMachine.TransitionTo(playerController.StateMachine.walkState);
        }

    }

    public void Exit()
    {
       
    }
}
