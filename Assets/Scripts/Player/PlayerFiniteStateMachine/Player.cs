using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables

    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerNeedleShootState NeedleShootState { get; private set; }
    public PlayerPineconeThrowState PineconeThrowState { get; private set; }

    #endregion

    #region Components

    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }

    #endregion

    #region Check Transforms

    private Transform groundCheck;

    #endregion

    #region Other Variables

    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    private Vector2 workSpace;

    [SerializeField]
    private PlayerData playerData;

    #endregion

    #region Unity Callback Functions

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        NeedleShootState = new PlayerNeedleShootState(this, StateMachine, playerData, "needleShoot");
        PineconeThrowState = new PlayerPineconeThrowState(this, StateMachine, playerData, "pineconeThrow");

        groundCheck = transform.Find("GroundCheck");
    }

    private void Start()
    {
        FacingDirection = 1;

        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();

        GetComponent<PlayerCombatHandler>().SetData(playerData, this);

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    #region Set Functions

    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetVelocityY(float velocity)
    {
        workSpace.Set(CurrentVelocity.x, velocity);
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    #endregion

    #region Check Functions

    public void CheckIfShouldFlip(float xInput)
    {
        if (xInput > 0)
        {
            xInput = 1;
        }
        else if (xInput < 0)
        {
            xInput = -1;
        }

        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, playerData.GroundCheckBox, 0f, playerData.WhatIsGround);
    }

    #endregion

    #region Other Functions

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    private void Flip()
    {
        FacingDirection *= -1;

        if (FacingDirection == 1)
        {
            transform.Rotate(0.0f, 220f, 0.0f);
        }
        if (FacingDirection == -1)
        {
            transform.Rotate(0.0f, 140f, 0.0f);
        }
    }

    #endregion
}
