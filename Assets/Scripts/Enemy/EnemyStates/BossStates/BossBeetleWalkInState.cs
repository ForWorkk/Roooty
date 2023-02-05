using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeetleWalkInState : EnemyState
{
    private float walkTime;
    private float maxWalkTime = 2;

    private BossBeetle boss;

    public BossBeetleWalkInState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        walkTime = 0;

        boss = enemy.GetComponent<BossBeetle>();

        enemy.SetVelocityY(0);
        boss.MoveForward(enemyData.WalkInSpeed);

        boss.SpawnRandomly();
    }

    public override void Exit()
    {
        base.Enter();

        walkTime = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        boss.MoveForward(enemyData.WalkInSpeed);

        walkTime += Time.deltaTime;
        if (walkTime >= maxWalkTime)
        {
            enemy.StateMachine.ChangeState(boss.ChargePrepState);
        }
    }
}
