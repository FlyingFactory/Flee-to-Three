using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public static class Resources
    {
        public static class Blocks
        {
            public static SpawnBlock Test1 = 
                new SpawnBlock(
                    size: new Vector2(3, 5),
                    spawners: new Spawner[]
                    {
                        new UnitSpawner(position: new Vector2(0, 1), spritename: "mammothbird"),
                        new UnitSpawner(position: new Vector2(1, 2), spritename: "mammothbird"),
                        new UnitSpawner(position: new Vector2(2, 3), spritename: "mammothbird"),
                        new UnitSpawner(position: new Vector2(3, 4), spritename: "mammothbird"),
                        new UnitSpawner(position: new Vector2(4, 5), spritename: "mammothbird"),
                    }
                );

            public static SpawnBlock Test2 =
                new SpawnBlock(
                    size: new Vector2(3f, 10f),
                    spawners: new Spawner[]
                    {
                        new PlatformSpawner(position: new Vector2(0, 0), size: new Vector2(3f, 1f)),
                        new UnitSpawner(position: new Vector2(1.5f, 2), spritename: "mammothbird"),
                        new PlatformSpawner(position: new Vector2(0, 4), size: new Vector2(3f, 1f)),
                        new UnitSpawner(position: new Vector2(1.5f, 6), spritename: "mammothbird"),
                        new PlatformSpawner(position: new Vector2(0, 8), size: new Vector2(3f, 1f)),
                    }
                );


            private static readonly SpawnBlock[] ALL_BLOCKS = Blocks.GetAllBlocks();
            private static SpawnBlock[] GetAllBlocks()
            {
                List<SpawnBlock> blocks = new List<SpawnBlock>();
                foreach (FieldInfo field in typeof(Blocks).GetFields())
                {
                    if (field.FieldType != typeof(SpawnBlock)) continue;

                    blocks.Add(field.GetValue(null) as SpawnBlock);
                }

                return blocks.ToArray();
            }


            public static SpawnBlock GetRandomBlock()
            {
                return ALL_BLOCKS[Random.Range(0, ALL_BLOCKS.Length)];
            }
            
        }
    }
}