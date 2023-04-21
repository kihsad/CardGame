using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWeaponAbility : Ability
{
    private Stat _destroyWeapon;
    public override void Apply(Card source, Card target, AbilityData data)
    {
        data.TryGetStat(StatType.DestroyWeapon, out _destroyWeapon);
        _target = target;
        _target._attack -= _target._attack;
    }

    public override void Cancel()
    {
        _target._attack += _target._attack;
    }
}
