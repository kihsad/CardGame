using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards.ScriptableObjects

{
    [CreateAssetMenu(fileName = "New PlayerConfiguration", menuName = "CardConfigs/Player Configuration", order = 51)]

    public class PlayerConfiguration : ScriptableObject
    {
        [SerializeField]
        public int _maxMana;
        
        [SerializeField]
        public int _maxHealth;


    }

}

