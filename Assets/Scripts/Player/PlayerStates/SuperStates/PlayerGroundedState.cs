using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Vector2 input;

    private bool jumpInput;
    private bool needleInput;
    private bool isGrounded;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        input = player.InputHandler.MovementInput;
        jumpInput = player.InputHandler.JumpInput;
        needleInput = player.InputHandler.NeedleInput;

        if (jumpInput)
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (needleInput)
        {
            player.StateMachine.ChangeState(player.NeedleShootState);
        }
        else if (!isGrounded)
        {
            player.StateMachine.ChangeState(player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
