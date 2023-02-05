using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNeedleShootState : PlayerAbilityState
{
    private float shootTime;
    private float maxShootTime = 0.2f;

    public PlayerNeedleShootState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        shootTime += Time.deltaTime;
        if (shootTime >= maxShootTime)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void Enter()
    {
        PlayerProjectile projectileObject = Object.Instantiate(playerData.NeedlePrefab, player.transform.position + new Vector3(1.5f * player.FacingDirection, .5f * 1.5f, 0), Quaternion.identity).GetComponent<PlayerProjectile>();
        projectileObject.SetTrajectory(new Vector2(player.FacingDirection, 0));

        shootTime = 0;
    }
}
