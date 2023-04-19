using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RestoreAbility : Ability
{
    private Stat _restore;
    private Card _card;

    public RestoreAbility()
    {

    }
    public override void Apply()
    {
        //_card.Health
    }

    public override void Cancel()
    {
        throw new System.NotImplementedException();
    }

    public override void SetData(AbilityData data, Card card)
    {
        data.TryGetStat(StatType.Restore, out _restore);
        _card = card;

    }
}
