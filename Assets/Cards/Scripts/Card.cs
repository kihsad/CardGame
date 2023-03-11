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

        private Camera _mainCamera;
        [HideInInspector] public Vector3 mousePosition;

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

        private void Start()
        {
            _deck = GetComponent<DeckManager>();
            _mainCamera = Camera.main;
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

        public static Card _card;
        private Vector3 _startPosition;
        public Vector3 _endPosition;
        //private HandPlayer _parents;


        //private void Awake()
        //{
        //    _parents = GetComponent<HandPlayer>();
        //}

        public void OnBeginDrag(PointerEventData eventData)
        {
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;

            _card = this;
            _startPosition = transform.position;
            //_startParent = _parents._positions;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 delta = eventData.delta;
            Vector3 newPosition = transform.localPosition + new Vector3(delta.x, 0f, delta.y);
            transform.localPosition = newPosition;

            //transform.localPosition = Input.mousePosition;
            //transform.position = eventData.pointerCurrentRaycast.screenPosition;
            //transform.position = eventData.position + eventData.delta;

        }


        public void OnEndDrag(PointerEventData eventData)
        {
            this.GetComponent<CanvasGroup>().blocksRaycasts = true;
            _endPosition = transform.position;
            _deck._tablePlayer1.SetCard(_card);

            Debug.Log("Card is attached to gizmo");

        }

        void Update()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Old Table")) continue;
                Debug.DrawLine(start: ray.origin, end: ray.origin + ray.direction * 100, Color.red);

                mousePosition = _mainCamera.ScreenToWorldPoint(new Vector3());
                
                mousePosition = hit.point;


                break;
            }

        }

       
        
    }
}