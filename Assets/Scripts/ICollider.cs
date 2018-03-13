using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains collider and its method, as well as the collider's center-to-side width/height. (Also, for convenience, its Team.)
/// </summary>
public interface ICollider : IKinematics {

    Collider2D collider { get; set; }
    float colliderwidthcs { get; set; }
    float colliderheightcs { get; set; }

    Team team { get; set; }

    void CollisionEnter(Collision2D collision, ICollider other, bool cont=false);
}
