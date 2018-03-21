using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawn;

namespace Spawn
{
    /// <summary>
    /// Spawns an enemy every fixed interval as the camera approaches the location. Temporary script, until terrain blocks are put in.
    /// </summary>
    public class EnemyGenerator : MonoBehaviour
    {

        /// <summary>
        /// How far the camera should be before spawning
        /// </summary>
        private const float SPAWN_BEFORE = 15f;
        
        private Vector2 lastSpawnPos = new Vector2(-SPAWN_BEFORE / 2, 0);
        
        private void FixedUpdate()
        {
            while (isSpawnNext())
            {
                this.lastSpawnPos = Resources.Blocks.GetRandomBlock().DoSpawnAt(this.lastSpawnPos);
            }
        }

        private bool isSpawnNext()
        {
            return lastSpawnPos.x - Camera.main.transform.position.x < SPAWN_BEFORE;
        }
    }
}