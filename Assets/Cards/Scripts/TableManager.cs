using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class TableManager : MonoBehaviour
    {
        private List<Card> _cards = new List<Card>();

        [SerializeField]
        public Transform[] _positions;

        public bool SetCard(Card card)
        {
            //var index = -1;
            //for(int i=0; i<_cards.Count; i++)
            //{
            //    if(_cards[i] == null)
            //    {
            //        index = i;
            //        break;
            //    }
            //}
            //if (index == -1)
            //{
            //    Destroy(card.gameObject);
            //    return false;
            //}

            //var index = -1;
            for (int i = 0; i < _cards.Count; i++)
            {
                _cards[i] = card;
                StartCoroutine(MoveOnTable(card, _positions[i]));

            }

            return true;
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
            //card.SwitchCard();
            card.State = CardStateType.OnTable;
        }
    }
}