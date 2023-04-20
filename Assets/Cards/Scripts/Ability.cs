using UnityEngine;
namespace Cards
{
    public abstract class Ability
    {
        protected Card _source, _target;

        public abstract void Apply(Card source, Card target, AbilityData data);
        public abstract void Cancel();

    }

}
