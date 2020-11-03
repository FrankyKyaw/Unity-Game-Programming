using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreatorKitCode;

public class DefenseUpEffect : UsableItem.UsageEffect
{
    public float Duration = 10.0f;
    public Sprite EffectSprite;
    public int DefenseChange = 10;
    public override bool Use(CharacterData user)
    {
        StatSystem.StatModifier modifier= new StatSystem.StatModifier();
        modifier.ModifierMode = StatSystem.StatModifier.Mode.Absolute;
        modifier.Stats.defense = DefenseChange;

        user.Stats.AddTimedModifier(StatSystem.StatModifier modifier,Duration,"DefenseUpEffect",EffectSprite);
        
        return true;
        
    }
}
