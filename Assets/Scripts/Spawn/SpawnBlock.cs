using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class SpawnBlock
    {
        public SpawnBlock(Vector2 size, IEnumerable<Spawner> spawners)
        {
            this.size = size;
            this.spawners = spawners;
        }

        private readonly Vector2 size;
        private readonly IEnumerable<Spawner> spawners;

        public Vector2 DoSpawnAt(Vector2 location)
        {
            foreach (Spawner spawner in this.spawners) spawner.DoSpawnAt(location);

            return location + new Vector2(this.size.x, 0);
        }
    }
}