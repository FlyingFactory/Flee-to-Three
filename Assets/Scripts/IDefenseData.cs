using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// health |
/// NoHealth() |
/// For damagable units and projectiles.
/// </summary>
public interface IDefenseData {

    float health { get; set; }

    void NoHealth();
}
