using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Constantly updates the sprite's position to the object's kinematics position. self stores a reference to the object the sprite represents.
/// </summary>
public class SpriteController : MonoBehaviour {

    public IHasSprite self;
    
    /*public static SpriteController Create(IHasSprite obj) {
        SpriteController p = Instantiate(PrefabResources.SpriteController);
        p.self = obj;
        return p;
    }*/

    // Use this for initialization
    void Start() {
        gameObject.GetComponent<SpriteRenderer>().sprite = self.sprite;
        transform.position = new Vector3(self.kinematics.pos.x, self.kinematics.pos.y, self.spriteOrder);
        if (self == PlayerManager.player) {
            CameraManager.playersprite = this;
            CameraManager.playerFollowEnabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(self.kinematics.pos.x, self.kinematics.pos.y, self.spriteOrder);
    }

    // Currently unused
    public void UpdateSprite() {
        gameObject.GetComponent<SpriteRenderer>().sprite = self.sprite;
    }
}
