using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class EndTurn : MonoBehaviour
    {
        [SerializeField]
        private GameObject _axis;
        private Card[] _cards;
        private DeckManager _deckManager;
        public void EndTheTurn()
        {
            _deckManager = FindObjectOfType<DeckManager>();
            _cards = FindObjectsOfType<Card>();
            StartCoroutine(TurnTable());
        }
        public IEnumerator TurnTable()
        {
            var time = 0f;
            var startPos = _axis.transform.eulerAngles;
            var endPos = _axis.transform.eulerAngles + new Vector3(0, 180, 0);
            //var startPos = _axis.transform.eulerAngles;
            //var endPos = _axis.transform.eulerAngles + new Vector3(startPos.x, startPos.y + 180f, startPos.z);
            while (time < 2f)
            {
                _axis.transform.eulerAngles = Vector3.Lerp(startPos, endPos, time);
                time += Time.deltaTime;
                yield return null;
            }
            foreach(Card card in _cards)
            {
                if (card.PositionInHand != null)
                {
                    _deckManager.CloseCards(card);
                }
            }
        }
    }
}