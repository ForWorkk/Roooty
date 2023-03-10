using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private float xInput;
    private bool isGrounded;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetGravityScale(1);
    }

    public override void Exit()
    {
        base.Exit();

        player.SetGravityScale(1);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.MovementInput.x;

        player.CheckIfShouldFlip(xInput);

        player.SetVelocityX(xInput * playerData.MoveSpeed);

        player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);


        if (isGrounded && player.CurrentVelocity.y < 0.0000001f)
        {
            stateMachine.ChangeState(player.IdleState);
        }

        if (player.CurrentVelocity.y < 3f)
        {
            player.SetGravityScale(3);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
