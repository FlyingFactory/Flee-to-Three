using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Workaround class for calling Instantiate from static classes. One instance of this must exist in the scene.
/// </summary>
public class PrefabCreator : MonoBehaviour {

    // This block handles sprites. Copy-paste and change types/names for new prefab types. Remember to add an entry to Update/FixedUpdate as well.
    public SpriteController SpritePrefab;
    public static List<ISprite> SpriteControllerQueue = new List<ISprite>();

    public static void CreateSprite(ISprite obj) {
        SpriteControllerQueue.Add(obj);
    }
    public void CreateSpriteFromList() {
        SpriteController newsprite = Instantiate<SpriteController>(SpritePrefab);
        newsprite.self = SpriteControllerQueue[0];
        SpriteControllerQueue.RemoveAt(0);
    } // End of sprite-related block. =================================================================================


    // Colliders ======================================================================================================
    public ColliderController ColliderPrefab;
    public static List<ICollider> ColliderControllerQueue = new List<ICollider>();

    public static void CreateCollider(ICollider obj) {
        ColliderControllerQueue.Add(obj);
    }
    public void CreateColliderFromList() {
        ColliderController newcollider = Instantiate<ColliderController>(ColliderPrefab);
        newcollider.self = ColliderControllerQueue[0];
        ColliderControllerQueue.RemoveAt(0);
    } // End colliders ================================================================================================


    //=================================================================================================================
    void Update () {
        while (SpriteControllerQueue.Count > 0) {
            CreateSpriteFromList();
        }
	}

    void FixedUpdate() {
        while (ColliderControllerQueue.Count > 0) {
            CreateColliderFromList();
        }
    }
}
