using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Loops through FixedUpdate, triggering TimeStep() on a static List&lt;ITimeStep&gt; Entities.
/// </summary>
public class TimeManager : MonoBehaviour {

    /// <summary>
    /// Add all things that respond to game time, on creation. Things should remove themselves when they 'die'.
    /// </summary>
    public static List<ITimeStep> Entities = new List<ITimeStep>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	/*void Update () {
        foreach (ITimeStep u in Entities) {
            u.TimeStep(Time.deltaTime);
        }
    }*/

    private void FixedUpdate() {
        foreach (ITimeStep u in Entities) {
            u.TimeStep(Time.fixedDeltaTime);
        }
    }
}
