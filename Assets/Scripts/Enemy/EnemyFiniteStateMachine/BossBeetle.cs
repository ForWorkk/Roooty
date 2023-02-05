using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeetle : Enemy
{
    [SerializeField] private bool isDancing;

    #region State Variables

    public BossBeetleWalkInState WalkInState { get; private set; }
    public BossBeetleChargePrepState ChargePrepState { get; private set; }
    public BossBeetleChargeState ChargeState { get; private set; }
    public BossBeetleDanceState DanceState { get; private set; }
    public BossBeetleDanceWalkInState DanceWalkInState { get; private set; }


    #endregion

    public BossRoom BossRoom;


    protected override void Awake()
    {
        base.Awake();
        WalkInState = new BossBeetleWalkInState(this, StateMachine, enemyData, "walkIn");
        ChargePrepState = new BossBeetleChargePrepState(this, StateMachine, enemyData, "chargePrep");
        ChargeState = new BossBeetleChargeState(this, StateMachine, enemyData, "charge");
        DanceState = new BossBeetleDanceState(this, StateMachine, enemyData, "dance");
        DanceWalkInState = new BossBeetleDanceWalkInState(this, StateMachine, enemyData, "walkIn");
    }

    protected override void Start()
    {
        base.Start();

        if (isDancing)
        {
            StateMachine.ChangeState(DanceWalkInState);
        }
        else
        {
            StateMachine.ChangeState(WalkInState);
        }
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

    public void SpawnRight()
    {
        Vector3 pos = BossRoom.GetRandomSpawnPosition();

        transform.position = new Vector3(pos.x * ((pos.x > 1) ? 1 : -1), pos.y, pos.z);
        Face(-1);
    }

    public void Face(int direction)
    {
        CheckIfShouldFlip(direction);
    }
}
