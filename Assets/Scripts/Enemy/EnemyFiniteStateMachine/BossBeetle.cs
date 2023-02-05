using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeetle : Enemy
{
    #region State Variables

    public BossBeetleWalkInState WalkInState { get; private set; }
    public BossBeetleChargePrepState ChargePrepState { get; private set; }
    public BossBeetleChargeState ChargeState { get; private set; }

    #endregion

    public BossRoom BossRoom;


    protected override void Awake()
    {
        base.Awake();
        WalkInState = new BossBeetleWalkInState(this, StateMachine, enemyData, "walkIn");
        ChargePrepState = new BossBeetleChargePrepState(this, StateMachine, enemyData, "chargePrep");
        ChargeState = new BossBeetleChargeState(this, StateMachine, enemyData, "charge");
    }

    protected override void Start()
    {
        base.Start();
        StateMachine.ChangeState(WalkInState);
    }

    public void MoveForward(float velocity)
    {
        SetVelocityX(velocity * FacingDirection);
    }

    public void SpawnRandomly()
    {
        Vector3 pos = BossRoom.GetRandomSpawnPosition();

        transform.position = pos;
        Face(pos.x > 0 ? -1 : 1);
    }

    public void Face(int direction)
    {
        CheckIfShouldFlip(direction);
    }
}
