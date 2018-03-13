using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Calls the CollisionEnter of the object. upon receiving a OnCollisionEnter2D from Unity.
/// </summary>
public class ColliderController : MonoBehaviour {

    public ICollider self;

    private void Start() {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if(boxCollider != null) {
            boxCollider.size = new Vector2(2*self.colliderwidthcs, 2*self.colliderheightcs);
        }
        transform.position = new Vector3(self.kinematics.pos.x, self.kinematics.pos.y, 0);
        EventManager.colliderDeath += ColliderDeathEvent;
    }

    private void FixedUpdate() {
        transform.position = new Vector3(self.kinematics.pos.x, self.kinematics.pos.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        self.CollisionEnter(collision, collision.collider.GetComponent<ColliderController>().self);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        self.CollisionEnter(collision, collision.collider.GetComponent<ColliderController>().self, true);
    }

    private void ColliderDeathEvent(ICollider deadobject) {
        if (deadobject == self) {
            EventManager.colliderDeath -= ColliderDeathEvent;
            Destroy(gameObject);
        }
    }
}
