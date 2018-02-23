using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// sprite |
/// kinematics |
/// All sprites will contain a kinematics, so use this for all sprites.
/// </summary>
public interface IHasSprite {

	Sprite sprite { get; set; }
    float spriteOrder { get; set; }

    Kinematics kinematics { get; set; }
}
