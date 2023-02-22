using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Cards
{
    public class Card : MonoBehaviour
    {
        private int _health;

        [SerializeField]
        private GameObject _frontCard;
        [SerializeField]
        private MeshRenderer _mesh;

        [Space, SerializeField]
        private TextMeshPro _costText;
        [SerializeField]
        private TextMeshPro _nameText;
        [SerializeField]
        private TextMeshPro _descriptionText;
        [SerializeField]
        private TextMeshPro _attackText;
        [SerializeField]
        private TextMeshPro _healthText;
        [SerializeField]
        private TextMeshPro _typeText;

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                _healthText.text = _health.ToString();
            }
        }

        public void Configuration(CardPropertiesData data, Material mat, string description)
        {
            _mesh.sharedMaterial = mat;
            _costText.text = data.Cost.ToString();
            _nameText.text = data.Name;
            _descriptionText.text = description;
            _attackText.text = data.Attack.ToString();
            _healthText.text = (_health = data.Health).ToString();
            _typeText.text = data.Type == CardUnitType.None ? string.Empty : data.Type.ToString();

        }
    }
}