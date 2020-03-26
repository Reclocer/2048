using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace G2048
{
    public class MarketItem : MonoBehaviour
    {
        [SerializeField] private Text _itemNumberT;
        private int _itemNumberI;
        public int ItemNumberI => _itemNumberI;

        [SerializeField] private Text _priceValueT;
        private int _priceValueI;
        public int PriceValueI => _priceValueI;        

        public MarketItem()
        {
            _itemNumberI = 1;
            _priceValueI = 100;
        }

        public MarketItem(int itemNumber, int priceValue)
        {
            _itemNumberI = itemNumber;
            _itemNumberT.text = itemNumber.ToString();

            _priceValueI = priceValue;
            _priceValueT.text = priceValue.ToString();
        } 
        
        /// <summary>
        /// Set item number
        /// </summary>
        /// <param name="itemNumber"></param>
        public void SetItemNumber(int itemNumber)
        {
            _itemNumberI = itemNumber;
            _itemNumberT.text = itemNumber.ToString();
        }

        /// <summary>
        /// Set price value
        /// </summary>
        /// <param name="priceValue"></param>
        public void SetPriceValue(int priceValue)
        {
            _priceValueI = priceValue*100;
            _priceValueT.text = _priceValueI.ToString();
        }
    }
}
