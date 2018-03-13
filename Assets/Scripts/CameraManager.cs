using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public const float CAMERA_ADJUST_MULT = 5f;
    public static bool playerFollowEnabled = false;
    public static SpriteController playersprite;
    public static float offset;

	// Use this for initialization
	void Start () {
        
	}

    // Legacy code: for when camera is attached to Update instead of FixedUpdate
    /*void Update() {
        if (playerFollowEnabled) {
            offset = transform.position.x - playersprite.transform.position.x - 5f;
            if (offset > 0.5) {
                Debug.Log((Time.deltaTime).ToString() + "   " + (CAMERA_ADJUST_MULT * (offset - 0.35f)).ToString());
                transform.position = new Vector3(transform.position.x - CAMERA_ADJUST_MULT * (offset - 0.35f) * Time.deltaTime, 0, -10);
            }
            if (offset < -0.5) {
                Debug.Log((Time.deltaTime).ToString() + "   " + (CAMERA_ADJUST_MULT * (offset - 0.35f)).ToString());
                transform.position = new Vector3(transform.position.x - CAMERA_ADJUST_MULT * (offset + 0.35f) * Time.deltaTime, 0, -10);
            }
        }
    }*/
    
    void FixedUpdate() {
        if (playerFollowEnabled) {
            offset = transform.position.x - playersprite.transform.position.x - 5f;
            if (offset > 0.5) {
                //Debug.Log((Time.fixedDeltaTime).ToString() + "   " + (CAMERA_ADJUST_MULT * (offset - 0.35f)).ToString());
                transform.position = new Vector3(transform.position.x - CAMERA_ADJUST_MULT * (offset - 0.35f) * Time.fixedDeltaTime, 0, -10);
            }
            if (offset < -0.5) {
                //Debug.Log((Time.fixedDeltaTime).ToString() + "   " + (CAMERA_ADJUST_MULT * (offset - 0.35f)).ToString());
                transform.position = new Vector3(transform.position.x - CAMERA_ADJUST_MULT * (offset + 0.35f) * Time.fixedDeltaTime, 0, -10);
            }
        }
    }
}
