namespace Cards
{
    public class RestoreAbility : Ability
    {
        private Stat _restore;

        public override void Apply(Card source, Card target, AbilityData data)
        {
            data.TryGetStat(StatType.RestoreHealth, out _restore);
            _source = source;
            _source.Health += _restore.Value;
        }

        public override void Cancel()
        {
            _source.Health -= _restore.Value;
        }

    }
}
