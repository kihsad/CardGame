using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class TableManager : MonoBehaviour
    {
        [SerializeField]
        public Transform[] _positions;
        private Card[] _cards;

        private void Awake()
        {
            _cards = new Card[_positions.Length];
        }

        public bool TrySetCard(Card card)
        {
            for (int i = 0; i < _cards.Length; i++)
            {
                if (_cards[i] = null)
                {
                    _cards[i] = card;
                    StartCoroutine(MoveCard(card, _positions[i]));
                    card.State = CardStateType.OnTable;
                    return true;
                }
                

            }

            return false;
        }

        private IEnumerator MoveCard(Card card, Transform position)
        {
            var time = 0f;
            var startPos = card.transform.position;
            var endPos = position.position;
            while (time < 1f)
            {
                card.transform.position = Vector3.Lerp(startPos, endPos, time);
                time += Time.deltaTime;
                yield return null;
            }
            
            
        }
    }
}