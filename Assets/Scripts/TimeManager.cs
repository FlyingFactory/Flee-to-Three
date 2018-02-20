using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public static List<ITimeStep> Entities = new List<ITimeStep>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        foreach (ITimeStep u in Entities) {
            u.TimeStep(Time.fixedDeltaTime);
        }
    }
}
