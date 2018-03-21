using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General framework for units. Orders its own sprite and collider from PrefabCreator.
/// </summary>
public class Unit : ITimeStep, ISprite, IDefenseData, ICollider {

    public const float COLLISION_PADDING = 0.01f;

    public Unit(string spritecode) : this(spritecode, Vector2.zero) { }
    public Unit(string spritecode, Vector2 pos) {
        kinematics = new Kinematics();
        kinematics.pos = pos;
        kinematics.g = 1;
        TimeManager.Entities.Add(this);

        sprite = Resources.Load<Sprite>(Filepaths.images[spritecode]);
        spriteOrder = 0;
        PrefabCreator.CreateSprite(this);

        colliderwidthcs = 1.2f;
        colliderheightcs = 0.8f;
        PrefabCreator.CreateCollider(this);

        team = Team.wildlifegeneric;
        health = 100;
    }

    private Kinematics _kinematics;
    public Kinematics kinematics {
        get { return _kinematics; }
        set { _kinematics = value; }
    }

    public Sprite sprite { get; set; }
    public float spriteOrder { get; set; }
    public AnimState animState { get; set; }

    public void TimeStep(float dt) {
        kinematics.TimeStep(dt);
        if (kinematics.pos.y == 0) isGrounded = true;
    }

    public Collider2D collider { get; set; }
    public float colliderwidthcs { get; set; }
    public float colliderheightcs { get; set; }

    public Team team { get; set; }
    private float _health;
    public float health {
        get { return _health; }
        set {
            if (value < float.Epsilon) {
                _health = 0;
                NoHealth();
            }
            else {
                _health = value;
            }
        }
    }

    public void NoHealth() {
        TimeManager.Entities.Remove(this);
        EventManager.dyingSprites.Add(this);
        EventManager.dyingColliders.Add(this);
    }

    public bool isGrounded = true; // To be used later when colliders are implemented

    public void Jump() {
        if (isGrounded) { 
            kinematics.v += new Vector2(0, 15);
            isGrounded = false;
        }
    }

    public void Shoot() {
        new Projectile(kinematics.pos, new Vector2(12, 0));
    }

    public void Left() {
        kinematics.v += new Vector2(-5, 0);
    }

    public void Right() {
        kinematics.v += new Vector2(5, 0);
    }

    public void CollisionEnter(Collision2D collision, ICollider other, bool cont=false) {
        if (other is Projectile)
            CollisionEnter(other as Projectile);
        if (other is Platform)
            CollisionEnter(other as Platform);
        // etc for remaining things to collide with (add a overloaded function below)
    }
    public void CollisionEnter(Projectile projectile) {
        if (health > 0f && health > float.Epsilon && team!=projectile.team) {
            health -= projectile.damage;
            Debug.Log(health);
            if (Mathf.Abs(health) < float.Epsilon) {
                Debug.Log(this + " is dead");
            }
        }
    }
    public void CollisionEnter(Platform platform) {

        float mx, my;

        //This code for orthogonal box platforms only
        /*Vector2 dir = kinematics.lastpos - platform.kinematics.pos;
        if (dir.x != 0) {
            
        } else return;*/

        mx = colliderwidthcs + platform.colliderwidthcs - Mathf.Abs(kinematics.pos.x - platform.kinematics.pos.x);
        my = colliderheightcs + platform.colliderheightcs - Mathf.Abs(kinematics.pos.y - platform.kinematics.pos.y);

        if (my < mx) {
            if (kinematics.pos.y >= platform.kinematics.pos.y) {
                kinematics.pos = new Vector2(kinematics.pos.x, platform.kinematics.pos.y + colliderheightcs + platform.colliderheightcs + COLLISION_PADDING);
                kinematics.v = new Vector2(kinematics.v.x, Mathf.Max(0, kinematics.v.y));
                isGrounded = true;
            }
            else {
                kinematics.pos = new Vector2(kinematics.pos.x, platform.kinematics.pos.y - colliderheightcs - platform.colliderheightcs - COLLISION_PADDING);
                //kinematics.v = new Vector2(kinematics.v.x, 0);
            }
        }
        else {
            if (kinematics.pos.x >= platform.kinematics.pos.x) {
                kinematics.pos = new Vector2(platform.kinematics.pos.x + colliderwidthcs + platform.colliderwidthcs + COLLISION_PADDING, kinematics.pos.y);
                //kinematics.v = new Vector2(0, kinematics.v.y);
            }
            else {
                kinematics.pos = new Vector2(platform.kinematics.pos.x - colliderwidthcs - platform.colliderwidthcs - COLLISION_PADDING, kinematics.pos.y);
                //kinematics.v = new Vector2(0, kinematics.v.y);
            }
        }
    }
}
