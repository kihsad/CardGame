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

        private DeckManager _deck;
        private HandPlayer _hand;

        public static Card _card;
        private float _distance;
        [SerializeField]
        private Collider[] _positions;

        public Vector3 PositionInHand { get; set; }
        [SerializeField]
        private LayerMask _tablePointLayer;

        private void Start()
        {
            _deck = FindObjectOfType<DeckManager>();
            _hand = FindObjectOfType<HandPlayer>();
        }

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
            switch (State)
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

        public void MoveToClosestPosition()
        {
            for (int i = 0; i < Physics.OverlapSphereNonAlloc(transform.position, _distance, _positions); i++)
            {
                var _closest = _positions[0].ClosestPoint(transform.position);
                _distance = Vector3.Distance(_card.transform.position, _positions[0].ClosestPoint(transform.position));
                _card.transform.Translate(_closest);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _card = this;
        }
        



        public void OnEndDrag(PointerEventData eventData)
        {
            //MoveToClosestPosition();
            for (int i = 0; i < Physics.OverlapSphereNonAlloc(transform.position, 100, _positions); i++)
            {
                Debug.Log(_positions[i]);
                if (_positions[i].TryGetComponent(out DrawCard cardPoint) && cardPoint.IsEmpty == false)
                {
                    transform.position = cardPoint.transform.position + Vector3.up * 5;
                    
                }

            }

            transform.position = PositionInHand;
            //_deck._tablePlayer1.TrySetCard(_card);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 delta = eventData.delta;
            Vector3 newPosition = transform.localPosition + new Vector3(delta.x, 0f, delta.y);
            transform.localPosition = newPosition;
        }

        //private void OnDrawGizmos()
        //{
           
        //        Gizmos.color = Color.red;
        //        Gizmos.DrawSphere(transform.position, 100);
          
        //}
    }
}