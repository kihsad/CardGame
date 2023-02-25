﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class HandPlayer : MonoBehaviour
    {
        private Card[] _cards;

        [SerializeField]
        private Transform[] _positions;

        private void Start()
        {
            _cards = new Card[_positions.Length];
        }

        public bool SetNewCard(Card card)
        {
            var index = -1;
            for(int i=0; i<_cards.Length; i++)
            {
                if(_cards[i] == null)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                Destroy(card.gameObject);
                return false;
            }

            _cards[index] = card;
            StartCoroutine(MoveInHand(card, _positions[index]));

            return true;
        }
        private IEnumerator MoveInHand(Card card, Transform position)
        {
            var time = 0f;
            var startPos = card.transform.position;
            var endPos = position.position;
            while(time<1f)
            {
                card.transform.position = Vector3.Lerp(startPos, endPos, time);
                time += Time.deltaTime;
                yield return null;
            }
            card.SwitchCard();
            card.State = CardStateType.InHand;
        }
    }
}