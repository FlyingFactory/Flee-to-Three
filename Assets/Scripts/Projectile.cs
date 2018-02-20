using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : ITimeStep, IHasSprite {

    public Projectile() : this(Vector2.zero){
        
    }
    public Projectile(Vector2 v) {
        kinematics.v = v;
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
}
