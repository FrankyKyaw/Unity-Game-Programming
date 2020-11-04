using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreatorKitCode;

public class Torso : EquipmentItem.EquippedEffect
{
     private int AddedDefense = 10;
     private int defense;
     public override void Equipped(CharacterData user)
     {
        StatSystem.StatModifier modifier = new StatSystem.StatModifier();
        modifier.ModifierMode = StatSystem.StatModifier.Mode.Absolute;
        modifier.Stats.defense = AddedDefense;
        user.Stats.AddModifier(modifier);
     }
     
     public override void Removed(CharacterData user)
     {
        StatSystem.StatModifier modifier = new StatSystem.StatModifier();
        modifier.ModifierMode = StatSystem.StatModifier.Mode.Absolute;
        modifier.Stats.defense = -AddedDefense;
        user.Stats.AddModifier(modifier);
        
     }
}
