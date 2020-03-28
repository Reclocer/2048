using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace G2048
{
    public class Content : MonoBehaviour
    {
        [SerializeField] private int _CountContent = 100;
        [SerializeField] private GameObject _marketItemPrefab;
        [SerializeField] private ScoreManager _scoreManager;
        private List<MarketItem> _marketItems;

        private void Awake()
        {
            Initialization();
        }

        private void Start()
        {            
            GenerateContent();
            CheckPrices();
        }

        private void Initialization()
        {
            _marketItems = new List<MarketItem>(_CountContent);
        }

        private void GenerateContent()
        {
            for (int i = 1; i <= _CountContent; i++)
            {
                MarketItem marketItem = Instantiate(_marketItemPrefab, this.transform).GetComponent<MarketItem>();
                marketItem.SetItemNumber(i);
                marketItem.SetPriceValue(i);
                _marketItems.Add(marketItem);
            }            
        }

        /// <summary>
        /// Compare prices in items with score
        /// </summary>
        public void CheckPrices()
        {
            if (_marketItems.Count != 0)
            {
                int score = _scoreManager.Score;

                for (int i = 0; i < _marketItems.Count; i++)
                {
                    int priceValue = _marketItems[i].PriceValueI;

                    if (score >= priceValue)
                    {
                        _marketItems[i]._buyBtn.interactable = true;
                    }
                    else
                    {
                        _marketItems[i]._buyBtn.interactable = false;
                    }
                }
            }
        }


    }
}
