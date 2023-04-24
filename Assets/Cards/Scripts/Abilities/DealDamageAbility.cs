namespace Cards
{
    public class DealDamageAbility : Ability
    {
        private Stat _dealDamage;
        public override void Apply(Card source, Card target, AbilityData data)
        {
            data.TryGetStat(StatType.DealDamage, out _dealDamage);
            _target = target;
            _target.Health -= _dealDamage.Value;
        }

        public override void Cancel()
        {
            _target.Health += _dealDamage.Value;
        }
    }
}