using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreatorKitCode;

public class AgilityUp : UsableItem.UsageEffect
{
    public float Duration = 10;
    public Sprite EffectSprite;
    public int AgilityChange = 20;
    public override bool Use(CharacterData user)
    {
        StatSystem.StatModifier modifier = new StatSystem.StatModifier();
        modifier.ModifierMode = StatSystem.StatModifier.Mode.Absolute;
        modifier.Stats.agility = AgilityChange;
        
        user.Stats.AddTimedModifier(modifier, Duration, "AgilityUp", EffectSprite);
        
        return true;
    }
}
