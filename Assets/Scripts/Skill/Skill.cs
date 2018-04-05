using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill {
    public Unit owner { get; private set; }   // owner is a unit

    public Skill(Unit unit) { owner = unit; }

    public abstract void onExecute();

    virtual public void execute() { onExecute(); }
}


public abstract class CooldownSkill : Skill
{
    private float maxCooldown;
    float currentCooldown = 0;
    public bool onCooldown
    {
        get { return (currentCooldown <= 0); }
        private set { onCooldown = value; }
    }

    public CooldownSkill(Unit unit, float cooldown) : base(unit)
    {
        maxCooldown = cooldown;
    }

    public override void execute()
    {
        if(!onCooldown)
        {
            onExecute();
            currentCooldown = maxCooldown; // set on cooldown
        }
    }

    public void timeStep(float dt) { currentCooldown -= dt; }
}


public abstract class OverSkill : Skill
{
    /// <summary>
    /// Overskill is a skill that usually overrides basic
    /// skills without cooldown. Instead of being unusable,
    /// overskills have a different behaviour when on cooldown.
    /// </summary>
    private float maxCooldown;
    float currentCooldown = 0;
    public bool onCooldown
    {
        get { return (currentCooldown <= 0); }
        private set { onCooldown = value; }
    }

    public OverSkill(Unit unit, float cooldown) : base(unit)
    {
        maxCooldown = cooldown;
    }

    public abstract void OnExecuteWithCooldown();

    public override void execute()
    {
        if (!onCooldown)
        {
            onExecute();
            currentCooldown = maxCooldown; // set on cooldown
        } else
        {
            OnExecuteWithCooldown();
        }
    }

    public void timeStep(float dt) { currentCooldown -= dt; }
}
