using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General framework for projectiles. Spawns its own sprite in the constructor. Optional argument (initial velocity as a Vector2) defaults to zero.
/// </summary>
public class Projectile : ITimeStep, IHasSprite {

    public Projectile() : this(Vector2.zero) { }
    public Projectile(Vector2 v) {
        kinematics.v = v;
        //SpriteController.Create(this);
        TimeManager.Entities.Add(this);
        sprite = Resources.Load<Sprite>(Filepaths.images["Placeholder_circle"]);
        spriteOrder = -1;
        PrefabCreator.CreateSprite(this);
    }

    private Kinematics _kinematics = new Kinematics();
    public Kinematics kinematics {
        get { return _kinematics; }
        set { _kinematics = value; }
    }

    public Sprite sprite { get; set; }
    public float spriteOrder { get; set; }

    public void TimeStep(float dt) {
        kinematics.TimeStep(dt);
    }
}
