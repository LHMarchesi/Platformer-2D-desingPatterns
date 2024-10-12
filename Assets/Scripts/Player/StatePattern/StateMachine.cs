using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateMachine 
{
    private IState currentState;
    public IState CurrentState => currentState;

    public WalkState walkState;
    public IdleState idleState;
    public JumpingState jumpingState;

    public StateMachine(PlayerController playerController)
    {
        walkState = new WalkState(playerController);
        idleState = new IdleState(playerController);
        jumpingState = new JumpingState(playerController);

    }

    public void Initialize(IState state)
    {
        currentState = state;
        currentState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        currentState.Exit();
        currentState = nextState;
        currentState.Enter();

    }

    public void Update()
    {
        if(currentState !=null)
        {
            currentState.Update();
        }
    }
}
