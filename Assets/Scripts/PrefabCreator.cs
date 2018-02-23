using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Workaround class for calling Instantiate from static classes. One instance of this must exist in the scene.
/// </summary>
public class PrefabCreator : MonoBehaviour {

    // This block handles sprites. Can copypaste and change types/names for new prefab types. Remember to add an entry to Update as well.
    public SpriteController SpritePrefab;
    public static List<IHasSprite> SpriteControllerQueue = new List<IHasSprite>();

    /// <summary>
    /// Creates a new sprite on next Update(). obj = script of the object the unit represents.
    /// </summary>
    public static void CreateSprite(IHasSprite obj) {
        SpriteControllerQueue.Add(obj);
    }
    public void CreateSpriteFromList() {
        SpriteController newsprite = Instantiate<SpriteController>(SpritePrefab);
        newsprite.self = SpriteControllerQueue[0];
        SpriteControllerQueue.RemoveAt(0);
    } // End of sprite-related block.
	

	void Update () {
        while (SpriteControllerQueue.Count > 0) {
            CreateSpriteFromList();
        }
	}
}
