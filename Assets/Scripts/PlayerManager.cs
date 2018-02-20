using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static Unit player; 

	// Use this for initialization
	void Start () {
        PlayerManager.player = new Unit();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W)) {
            player.Jump();
        }
        if (Input.GetMouseButtonDown(0)) {
            player.Shoot();
        }
    }


}
