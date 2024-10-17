using System;
public class AttackingState : IState
{
    private PlayerController playerController;

    public AttackingState(PlayerController player)
    {
        playerController = player;
    }

    public void Enter()
    {
        playerController.Animator.SetBool("IsAttacking", true);
    }

    public void Update()
    {
        Console.WriteLine("atacando");
    }

    public void Exit()
    {
        playerController.Animator.SetBool("IsAttacking", false);
    }
}
