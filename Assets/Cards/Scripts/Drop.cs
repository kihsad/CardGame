using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cards
{
    public class Drop : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            var card = Card._card;
            if (card != null)
            {
                card.transform.SetParent(transform);
            }
        }
    }
}