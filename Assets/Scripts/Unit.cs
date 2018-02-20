using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : ITimeStep, IHasSprite {

    public Unit() {
        kinematics.g = 1;
        SpriteController.Create(this);
        TimeManager.Entities.Add(this);
    }

    private Kinematics _kinematics = new Kinematics();
    public Kinematics kinematics {
        get { return _kinematics; }
        set { _kinematics = value; }
    }

    public Sprite sprite { get; set; }

    public void TimeStep(float dt) {
        kinematics.TimeStep(dt);
    }

    public void Jump() {
        kinematics.v += new Vector2(0, 15);
    }

    public void Shoot() {
        new Projectile(new Vector2(10, 0));
    }
}
