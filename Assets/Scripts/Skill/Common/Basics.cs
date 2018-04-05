using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Basic implementation

public class Jump : Skill
{
    public Jump(Unit unit) : base(unit) { }

    override public void onExecute()
    {
        if (owner.isGrounded)
        {
            owner.kinematics.v += new Vector2(0, 15);
            owner.isGrounded = false;
        }
    }
}

public class WalkRight : Skill
{
    public WalkRight(Unit unit) : base(unit) { }

    public override void onExecute()
    {
        owner.kinematics.v += new Vector2(5, 0);
    }
}


public class WalkLeft : Skill
{
    public WalkLeft(Unit unit) : base(unit) { }

    public override void onExecute()
    {
        owner.kinematics.v += new Vector2(-5, 0);
    }
}


public class WalkStop : Skill
{
    public WalkStop(Unit unit) : base(unit) { }

    public override void onExecute()
    {
        // not sure if correct implementation
        owner.kinematics.v.x = 0;
    }
}

public class Shoot : CooldownSkill
{
    public Shoot(Unit unit) : base(unit, 2) { } // default 2s

    public override void onExecute()
    {
        new Projectile(owner.kinematics.pos, new Vector2(12, 0));
    }
}