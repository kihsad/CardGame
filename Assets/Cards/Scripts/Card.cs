using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace Cards
{
    public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private int _health;
        private static readonly Vector3 _stepPosition = new Vector3(0f, 5f, 0f);
        private const float _scale = 2f;

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
        public CardStateType State { get; set; } = CardStateType.InDeck;

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

        public void OnPointerEnter(PointerEventData eventData)
        {
            switch(State)
            {
                case CardStateType.InHand:
                    transform.localPosition += _stepPosition;
                    transform.localScale *= _scale;
                    break;
                case CardStateType.OnTable:
                    break;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            switch (State)
            {
                case CardStateType.InHand:
                    transform.localPosition -= _stepPosition;
                    transform.localScale /= _scale;
                    break;
                case CardStateType.OnTable:
                    break;
            }
        }

        [ContextMenu("Switch card")]
        public void SwitchCard()
        {
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
            
        }

        public void OnDrag(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
            //eventData.
            //transform.position += eventData.;
        }
    }
}