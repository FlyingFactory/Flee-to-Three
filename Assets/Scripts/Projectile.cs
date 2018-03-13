using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General framework for projectiles. Spawns its own sprite in the constructor. Optional argument (initial velocity as a Vector2) defaults to zero.
/// </summary>
public class Projectile : ITimeStep, ISprite, ICollider {

    public Projectile() : this(Vector2.zero, Vector2.zero) { }
    public Projectile(Vector2 pos) : this(pos, Vector2.zero) { }
    public Projectile(Vector2 pos, Vector2 v) {

        kinematics.pos = pos;
        kinematics.v = v;
        TimeManager.Entities.Add(this);

        sprite = Resources.Load<Sprite>(Filepaths.images["Placeholder_circle"]);
        spriteOrder = -1;
        PrefabCreator.CreateSprite(this);

        colliderwidthcs = 0.2f;
        colliderheightcs = 0.2f;
        PrefabCreator.CreateCollider(this);

        // TEMPORARY DEFAULTS: replace with proper functionality
        team = Team.player;
        damage = 10;
    }

    public Team team { get; set; }
    public float damage;

    private Kinematics _kinematics = new Kinematics();
    public Kinematics kinematics {
        get { return _kinematics; }
        set { _kinematics = value; }
    }

    public Sprite sprite { get; set; }
    public float spriteOrder { get; set; }
    public AnimState animState { get; set; }

    public Collider2D collider { get; set; }
    public float colliderwidthcs { get; set; }
    public float colliderheightcs { get; set; }

    public void TimeStep(float dt) {
        kinematics.TimeStep(dt);
    }

    public void CollisionEnter(Collision2D collision, ICollider other, bool cont=false) {
        // Not implemented (use events to trigger death anim, delete this class)

        // "Delete" block
        if (!(other is Projectile) && other.team!=team) {
            TimeManager.Entities.Remove(this);
            EventManager.dyingSprites.Add(this);
            EventManager.dyingColliders.Add(this);
        }
    }
}
