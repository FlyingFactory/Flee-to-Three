using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All sprites have kinematics, so this inherits from kinematics.
/// </summary>
public interface ISprite : IKinematics {

	Sprite sprite { get; set; }
    float spriteOrder { get; set; }
    
    AnimState animState { get; set; }
}
