using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : Skill {
    private bool didDoubleJump = false;

    public DoubleJump(Unit unit) : base(unit) { }

    public override void onExecute()
    {
        if (owner.isGrounded)
        {
            owner.kinematics.v += new Vector2(0, 15);
            owner.isGrounded = false;
            didDoubleJump = false; // first jumping resets didDoubleJump
        } else if (!didDoubleJump)
        {
            owner.kinematics.v += new Vector2(0, 15);
            didDoubleJump = true;
        }
    }
}
