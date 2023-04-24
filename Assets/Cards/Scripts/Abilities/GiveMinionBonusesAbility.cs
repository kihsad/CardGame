﻿namespace Cards
{
    public class GiveMinionBonusesAbility : Ability
    {
        private Stat _minionBonuses;
        public override void Apply(Card source, Card target, AbilityData data)
        {
            data.TryGetStat(StatType.GiveMinionBonuses, out _minionBonuses);
            _target = target;
            if (_target._typeText.Equals(CardUnitType.None))
            {
                _target._attack += _minionBonuses.Value;
                _target.Health += _minionBonuses.Value;
            }
        }
        public override void Cancel()
        {
            _target._attack -= _minionBonuses.Value;
            _target.Health -= _minionBonuses.Value;
        }
    }
}