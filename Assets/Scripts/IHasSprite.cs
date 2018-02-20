using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasSprite {

	Sprite sprite { get; set; }

    Kinematics kinematics { get; set; }
}
