using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeetleDanceState : EnemyState
{
    private float danceTime;
    private float maxDanceTime = 6;

    public BossBeetleDanceState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.Anim.SetBool("walkIn", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        danceTime += Time.deltaTime;
        if (danceTime >= maxDanceTime)
        {
            stateMachine.ChangeState(enemy.GetComponent<BossBeetle>().ChargePrepState);
        }
    }
}
