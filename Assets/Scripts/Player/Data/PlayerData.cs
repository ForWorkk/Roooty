using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    [SerializeField] private float moveSpeed;

    public float MoveSpeed => moveSpeed;

    [Header("Jump State")]
    [SerializeField] private float jumpVelocity;

    public float JumpVelocity => jumpVelocity;

    [Header("In Air State")]
    [SerializeField] private float inAirAcceleration;

    public float InAirAcceleration => inAirAcceleration;




    [Header("Needle Shot State")]
    [SerializeField] private GameObject needlePrefab;

    public GameObject NeedlePrefab => needlePrefab;

    [Header("Pinecone Throw State")]
    [SerializeField] private GameObject pineconeGrenadePrefab;
    [SerializeField] private Vector2 throwTrajectory;

    public GameObject PineconeGrenadePrefab => pineconeGrenadePrefab;
    public Vector2 ThrowTrajectory => throwTrajectory;




    [Header("Check Variables")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Vector2 groundCheckBox;

    public LayerMask WhatIsGround => whatIsGround;
    public Vector2 GroundCheckBox => groundCheckBox;
}
