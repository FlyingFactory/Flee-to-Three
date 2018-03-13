using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Constantly updates the sprite's position to the object's kinematics position. self stores a reference to the object the sprite represents.
/// </summary>
public class SpriteController : MonoBehaviour {

    private ISprite _self;
    public ISprite self;
        /*
        get { return this._self; }
        set {
            ColliderController collide_controller = this.GetComponent<ColliderController>();
            if (value is ICollider && !collide_controller) {
                collide_controller = this.gameObject.AddComponent<ColliderController>();
            }
            if (value is ICollider) {
                collide_controller.self = (ICollider)value;
            }
            this._self = value;
        }
    }*/

    // Use this for initialization
    void Start() {
        gameObject.GetComponent<SpriteRenderer>().sprite = self.sprite;
        transform.position = new Vector3(self.kinematics.pos.x, self.kinematics.pos.y, self.spriteOrder);
        if (self == PlayerManager.player) {
            CameraManager.playersprite = this;
            CameraManager.playerFollowEnabled = true;
        }
        EventManager.spriteDeath += SpriteDeathEvent;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(self.kinematics.pos.x, self.kinematics.pos.y, self.spriteOrder);
    }

    // Currently unused
    public void UpdateSprite() {
        gameObject.GetComponent<SpriteRenderer>().sprite = self.sprite;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (self is ICollider) {
            ((ICollider)self).CollisionEnter(collision, collision.gameObject.GetComponent<ICollider>());
        }
    }

    private void SpriteDeathEvent(ISprite deadobject) {
        if (deadobject == self) {
            EventManager.spriteDeath -= SpriteDeathEvent;
            Destroy(gameObject);
        }
    }
}
