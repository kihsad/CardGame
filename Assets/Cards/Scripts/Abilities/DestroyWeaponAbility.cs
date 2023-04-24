namespace Cards
{
    public class DestroyWeaponAbility : Ability
    {
        private Stat _destroyWeapon;
        public override void Apply(Card source, Card target, AbilityData data)
        {
            data.TryGetStat(StatType.DestroyWeapon, out _destroyWeapon);
            _target = target;
            _destroyWeapon.Value = _target._attack;
            _target._attack -= _destroyWeapon.Value;
        }

        public override void Cancel()
        {
            _target._attack += _destroyWeapon.Value;
        }
    }
}