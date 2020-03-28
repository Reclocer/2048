using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace G2048
{
    public class MarketItem : MonoBehaviour
    {
        public Button _buyBtn;

        [SerializeField] private Text _itemNumberT;
        private int _itemNumberI;
        public int ItemNumberI => _itemNumberI;

        [SerializeField] private Text _priceValueT;
        private int _priceValueI;
        public int PriceValueI => _priceValueI;
                
        private int _amountOfPurchases = 0;
        private ScoreManager _scoreManager;
        private Cart _cart;
        private Content _content;

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

        private void Start()
        {
            Initialization();            
        }

        private void Initialization()
        {
            _scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
            _cart = GameObject.FindGameObjectWithTag("Cart").GetComponent<Cart>();
            _content = GameObject.FindGameObjectWithTag("Content").GetComponent<Content>();

            _buyBtn.onClick.AddListener(() => _cart.AddBoughtItem(this));
            _buyBtn.onClick.AddListener(() => _content.CheckPrices());
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

        /// <summary>
        /// Increnment price value
        /// </summary>
        public void IncrementPrice()
        {
            _scoreManager.DecrementScore(_priceValueI);

            _amountOfPurchases++;
            _priceValueI += _itemNumberI * 100 * ((_amountOfPurchases+1)^2);            
            _priceValueT.text = _priceValueI.ToString();           
        }
    }
}
