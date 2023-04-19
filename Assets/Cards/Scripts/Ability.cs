using UnityEngine;
namespace Cards
{
    public abstract class Ability
    {
        public abstract void Apply();
        public abstract void Cancel();
        public abstract void SetData(AbilityData data, Card card);

    }

}
