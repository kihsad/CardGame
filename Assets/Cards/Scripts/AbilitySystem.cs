using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cards
{
    public class AbilitySystem : MonoBehaviour
    {
        [SerializeField]
        private Stat[] _stats;

        public bool TryGetStat(StatType type, out Stat stat)
        {
            stat = _stats.SingleOrDefault(s => s.Type == type);
            return stat.Equals(default(Stat));
        }

        public Stat GetStat(StatType type) => _stats.SingleOrDefault(s => s.Type == type);

        private Dictionary<StatType, Ability> _abilities = new Dictionary<StatType, Ability>();
        private void Awake()
        {
            _abilities.Add(StatType.DealDamage, new DealDamageAbility(GetStat(StatType.DealDamage)));
        }

        public void ApplyAbilityByType(Card source, Card target, StatType type)
        {
            if (_abilities.TryGetValue(type, out var currentAbility))
            {
                currentAbility.Apply(source, target);
            }
        }

    }
}