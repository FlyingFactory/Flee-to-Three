using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {

    public IHasSprite self;
    // Use this for initialization
    void Start() {
    }
    
    public static SpriteController Create(IHasSprite obj) {
        SpriteController p = Instantiate<SpriteController>(PrefabResources.SpriteController);
        p.self = obj;
        return p;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = self.kinematics.pos;
	}
}
