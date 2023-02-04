using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }
    public bool JumpInput { get; private set; }

    public bool NeedleInput { get; private set; }

    private void Update()
    {
        MovementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        JumpInput = Input.GetKeyDown(KeyCode.Space);

        NeedleInput = Input.GetKeyDown(KeyCode.E);
    }
}
