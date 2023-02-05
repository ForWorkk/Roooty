using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeetleChargeState : EnemyState
{
    private float chargeTime;
    private float maxChargeTime;

    private BossBeetle boss;

    public BossBeetleChargeState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        maxChargeTime = Random.Range(2f, 4f);

        boss = enemy.GetComponent<BossBeetle>();
    }

    public override void Exit()
    {
        base.Enter();

        chargeTime = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        boss.MoveForward(enemyData.ChargeSpeed);

        chargeTime += Time.deltaTime;
        if (chargeTime >= maxChargeTime)
        {
            stateMachine.ChangeState(boss.WalkInState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
