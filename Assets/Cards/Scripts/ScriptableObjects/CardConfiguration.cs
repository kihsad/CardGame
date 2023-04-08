using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards.ScriptableObjects
{
    [CreateAssetMenu(fileName ="New CardConfiguration", menuName = "CardConfigs/Card Configuration", order =51)]
    public class CardConfiguration : ScriptableObject
    {
        [SerializeField]
        private int _cost;
        [SerializeField]
        private int _id;
        [SerializeField]
        private string _name;
        [SerializeField]
        private Texture _texture;
        [SerializeField]
        private int _attack;
        [SerializeField]
        private int _health;
        [SerializeField]
        private CardUnitType _type;
        [SerializeField]
        private string _description;

    }
}