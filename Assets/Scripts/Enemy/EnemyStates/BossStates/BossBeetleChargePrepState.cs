using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeetleChargePrepState : EnemyState
{
    private float chargeTime;
    private float maxChargeTime = 2;

    public BossBeetleChargePrepState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        chargeTime = 0;

        enemy.SetVelocityX(0);
    }

    public override void Exit()
    {
        base.Exit();

        chargeTime = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        chargeTime += Time.deltaTime;
        if (chargeTime >= maxChargeTime)
        {
            enemy.StateMachine.ChangeState(enemy.GetComponent<BossBeetle>().ChargeState);
        }
    }
}
