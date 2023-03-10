using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cards
{
    public class Drop : MonoBehaviour, IDropHandler
    {
        List<Transform> positions = new List<Transform>();
        public Transform target;
        private Transform _startPos;
        private Transform _endPos;
        private Card _card;
        private void Start()
        {
            Transform positionsObject = FindObjectOfType<Drop>().transform;
            foreach (Transform t in positionsObject)
                positions.Add(t);
            _card = GetComponent<Card>();
            _startPos = _card.transform;
            _endPos = positions[0];
        }
        public void OnDrop(PointerEventData eventData)
        {
            var card = Card._card;
            if (card != null)
            {
                
            }
        }
    }
}