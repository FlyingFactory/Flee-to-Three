using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Players controls tied to Update(). Spawns player unit in Start().
/// </summary>
public class PlayerManager : MonoBehaviour {

    public static Unit player; 

	// Use this for initialization
	void Start () {
        PlayerManager.player = new Unit("tyrant");
        player.team = Team.player;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W)) {
            player.Jump();
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            player.Left();
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            player.Right();
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            player.Right();
        }
        if (Input.GetKeyUp(KeyCode.D)) {
            player.Left();
        }
        if (Input.GetMouseButtonDown(0)) {
            player.Shoot();
        }
    }


}
