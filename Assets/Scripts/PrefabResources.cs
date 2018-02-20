using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabResources : MonoBehaviour {

    public static SpriteController SpriteController {
        get { return _instance.spriteController; }
    }

    [SerializeField]
    private SpriteController spriteController;

    private static PrefabResources _instance;

    private void Awake() {
        _instance = this;
    }
    
}