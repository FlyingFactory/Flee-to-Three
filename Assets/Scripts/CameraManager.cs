using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public const float CAMERA_ADJUST_MULT = 0.1f;
    public static bool playerFollowEnabled = false;
    public static SpriteController playersprite;
    public static float offset;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (playerFollowEnabled) {
            offset = transform.position.x - playersprite.transform.position.x - 5f; 
            if (offset > 0.5) {
                transform.position = new Vector3(transform.position.x - CAMERA_ADJUST_MULT * (offset - 0.35f), 0, -10);
            }
            if (offset < -0.5) {
                transform.position = new Vector3(transform.position.x - CAMERA_ADJUST_MULT * (offset + 0.35f), 0, -10);
            }
        }
    }
}
