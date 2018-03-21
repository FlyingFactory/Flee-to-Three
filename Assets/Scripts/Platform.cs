using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : ICollider, ISprite {

    public Platform(Vector2 pos, Vector2 size) : this(pos, size.x, size.y) { }
    public Platform(Vector2 pos, float w, float h) {
        kinematics.pos = pos;
        colliderwidthcs = w;
        colliderheightcs = h;

        sprite = Resources.Load<Sprite>(Filepaths.images["rblack"]);
        spriteOrder = 1;
        PrefabCreator.CreateSprite(this);

        colliderwidthcs = w/2;
        colliderheightcs = h/2;
        PrefabCreator.CreateCollider(this);

        team = Team.environment;
    }

    public Sprite sprite { get; set; }
    public AnimState animState { get; set; }
    public float spriteOrder { get; set; }

    private Kinematics _kinematics = new Kinematics();
    public Kinematics kinematics {
        get { return _kinematics; }
        set { _kinematics = value; }
    }

    public Team team { get; set; }

    public Collider2D collider { get; set; }
    public float colliderwidthcs { get; set; }
    public float colliderheightcs { get; set; }

    public void CollisionEnter(Collision2D collision, ICollider other, bool cont=false) {
        // Currently platforms do nothing
    }
}
