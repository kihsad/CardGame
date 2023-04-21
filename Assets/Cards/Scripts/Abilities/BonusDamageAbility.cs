using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDamageAbility : Ability
{
    private Stat _bonusDamage;
    public override void Apply(Card source, Card target, AbilityData data)
    {
        data.TryGetStat(StatType.BonusDamage, out _bonusDamage);
        _source = source;
        _source._attack += _bonusDamage.Value;
    }

    public override void Cancel()
    {
        _source._attack -= _bonusDamage.Value;
    }

}
