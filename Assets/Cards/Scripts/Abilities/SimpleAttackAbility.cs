namespace Cards
{
    public class SimpleAttackAbility : Ability
    {
        private Stat _attack;
        public override void Apply(Card source, Card target, AbilityData data)
        {
            data.TryGetStat(StatType.SimpleAttack, out _attack);
            _target = target;
            _target.Health -= _attack.Value;
        }

        public override void Cancel()
        {
            _target.Health += _attack.Value;
        }
    }
}