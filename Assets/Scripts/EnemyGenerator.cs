using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns an enemy every fixed interval as the camera approaches the location. Temporary script, until terrain blocks are put in.
/// </summary>
public class EnemyGenerator : MonoBehaviour {

    public const float SPAWN_INTERVAL = 20f;
    public float lastSpawnPos = -10f;
    public int skip = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        if (skip > 0) skip -= 1;
        else if (Camera.main.transform.position.x - lastSpawnPos > SPAWN_INTERVAL) {
            Unit newEnemy = new Unit("mammothbird");
            newEnemy.kinematics.pos = new Vector2(Camera.main.transform.position.x + 15, 0);
            lastSpawnPos = Camera.main.transform.position.x;

            /*Platform newPlatform = */new Platform(new Vector2(Camera.main.transform.position.x + 17, 2.5f), 4, 1);
        }
    }
}
