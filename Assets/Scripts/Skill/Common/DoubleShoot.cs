using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShoot : CooldownSkill
{
    public DoubleShoot(Unit unit) : base(unit, 2.5f) { } // default 2.5s

    public override void onExecute()
    {
        Vector2 upperProjectile = owner.kinematics.pos + new Vector2(0, 3);
        new Projectile(upperProjectile, new Vector2(8, 0));
        Vector2 lowerProjectile = owner.kinematics.pos + new Vector2(0, 3);
        new Projectile(lowerProjectile, new Vector2(8, 0));
    }
}