using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void SpriteDeath(ISprite sprite);
    public static event SpriteDeath spriteDeath;
    public static List<ISprite> dyingSprites = new List<ISprite>();

    public delegate void ColliderDeath(ICollider collider);
    public static event ColliderDeath colliderDeath;
    public static List<ICollider> dyingColliders = new List<ICollider>();

    private void FixedUpdate() {
        if (spriteDeath != null) {
            foreach (ISprite item in dyingSprites) {
                spriteDeath(item);
            }
        }
        dyingSprites.Clear();

        if (colliderDeath != null) {
            foreach (ICollider item in dyingColliders) {
                colliderDeath(item);
            }
        }
        dyingColliders.Clear();
    }
}
