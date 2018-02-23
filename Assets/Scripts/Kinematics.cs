using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic 2D kinematics information. Position, velocity, acceleration as Vector2, and gravity as positive float multiplier of global gravity.
/// </summary>
public class Kinematics : ITimeStep {

    public float g = 0;

    /// <summary>
    /// Global gravity value. Specific instances have their own multiplier.
    /// </summary>
    public const float G = -15;

    public Vector2 v = new Vector2(0, 0);
    public Vector2 a = new Vector2(0, 0);

    private Vector2 _pos = new Vector2(0, 0);
    public Vector2 pos {
        get { return _pos; }
        set {
            _pos = new Vector2(value.x, Mathf.Max(0f, value.y));
            if (_pos.y == 0f) v = new Vector2(v.x, 0);
        }
    }

    public void TimeStep(float dt) {
        v += a * dt + new Vector2(0, g*G * dt);
        pos += v * dt;
    }
}
