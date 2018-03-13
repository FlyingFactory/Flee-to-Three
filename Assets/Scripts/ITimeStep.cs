using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TimeStep() |
/// For all classes that respond to game-time; i.e. that which stops when you press pause.
/// </summary>
public interface ITimeStep {

    void TimeStep(float dt);
}
