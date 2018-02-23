using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General framework for units. Spawns its own sprite in the constructor.
/// </summary>
public class Unit : ITimeStep, IHasSprite {

    public Unit() {
        kinematics.g = 1;
        //SpriteController.Create(this);
        TimeManager.Entities.Add(this);
        sprite = Resources.Load<Sprite>(Filepaths.images["Placeholder_photo"]);
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

    public bool isGrounded = true; // To be used later when colliders are implemented

    public void Jump() {
        if (kinematics.pos.y==0) {
            kinematics.v += new Vector2(0, 10);
            isGrounded = false;
        }
    }

    public void Shoot() {
        new Projectile(new Vector2(10, 0));
    }

    public void Left() {
        kinematics.v += new Vector2(-5, 0);
    }

    public void Right() {
        kinematics.v += new Vector2(5, 0);
    }
}
