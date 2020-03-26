using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace G2048
{
    public class ContentGenerator : MonoBehaviour
    {
        [SerializeField] private int _CountContent = 100;
        [SerializeField] private GameObject _marketItemPrefab;

        // Start is called before the first frame update
        private void Start()
        {
            for (int i = 1; i <= _CountContent; i++)
            {
                MarketItem marketItem = Instantiate(_marketItemPrefab, this.transform).GetComponent<MarketItem>();
                marketItem.SetItemNumber(i);
                marketItem.SetPriceValue(i);
            }
        }
    }
}
