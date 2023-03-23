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

        public bool SetCard(Card card)
        {
            for (int i = 0; i < _cards.Length; i++)
            {
                _cards[i] = card;
                StartCoroutine(MoveOnTable(card, _positions[i]));
                return true;

            }

            return false;
        }

        private IEnumerator MoveOnTable(Card card, Transform position)
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
            card.State = CardStateType.OnTable;
        }
    }
}