using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner {

    public readonly Vector2 position;
    
    public Spawner(Vector2 position)
    {
        this.position = position;
    }

    public abstract void DoSpawnAt(Vector2 location);
}

public class UnitSpawner : Spawner
{
    private readonly string spritename;
    
    public UnitSpawner(Vector2 position, string spritename) : base(position)
    {
        this.spritename = spritename;
    }

    public override void DoSpawnAt(Vector2 location)
    {
        new Unit(this.spritename, location + this.position);
    }
}

public class PlatformSpawner : Spawner
{
    private readonly Vector2 size;

    public PlatformSpawner(Vector2 position, Vector2 size) : base(position) {
        this.size = size;
    }

    public override void DoSpawnAt(Vector2 location)
    {
        new Platform(location + this.position, this.size);
    }
}