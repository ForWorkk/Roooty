using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished || true)
        {
            player.StateMachine.ChangeState(player.InAirState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        player.SetVelocityY(playerData.JumpVelocity);

        isAbilityDone = true;
    }
}
