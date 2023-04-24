namespace Cards
{
    public class MurlocBonusAttackAbility : Ability
    {
        private Stat _murlocAttack;
        public override void Apply(Card source, Card target, AbilityData data)
        {
            data.TryGetStat(StatType.MurlocHaveBonusAttack, out _murlocAttack);
            _target = target;
            if (_target._typeText.Equals(CardUnitType.Murloc))
            {
                _target._attack += _murlocAttack.Value;
            }
        }

        public override void Cancel()
        {
            _target._attack -= _murlocAttack.Value;
        }

    }
}