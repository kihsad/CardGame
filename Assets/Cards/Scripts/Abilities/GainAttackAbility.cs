namespace Cards
{
    public class GainAttackAbility : Ability
    {
        private Stat _gainAttack;
        public override void Apply(Card source, Card target, AbilityData data)
        {
            data.TryGetStat(StatType.GainAttack, out _gainAttack);
            _source = source;
            if (_source.Health<_source._health)
            {
                _source._attack += _gainAttack.Value;
            }
        }

        public override void Cancel()
        {
            _source._attack -= _gainAttack.Value;
        }

    }
}
