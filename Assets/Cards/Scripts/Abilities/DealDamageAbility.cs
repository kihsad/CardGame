namespace Cards
{
    public class DealDamageAbility : Ability
    {
        private Stat _dealDamage;
        private AbilityData _data;
        public DealDamageAbility(Stat dealDamage)
        {
            _dealDamage = dealDamage;

        }
        public override void Apply(Card source, Card target)
        {
            _target = target;
            _target.Health -= _dealDamage.Value;
        }

        public override void Cancel()
        {
            _target.Health += _dealDamage.Value;
        }
    }
}