using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace G2048
{
    public class Cart : MonoBehaviour
    {
        private Queue<MarketItem> _boughtItems = new Queue<MarketItem>();
        public  Queue<MarketItem>  BoughtItems => _boughtItems;

        [SerializeField] private CellsManager _cellsManager;       

        /// <summary>
        /// Add bought item value in queue
        /// </summary>
        /// <param name="itemValue"></param>
        public void AddBoughtItem(MarketItem marketItem)
        {
            _boughtItems.Enqueue(marketItem);
        }

        public void UploadCart()
        {            
            for(int i = 0; i <= _boughtItems.Count+1; i++)
            {
                if (_boughtItems.Count > 0)
                {
                    int itemNumber = _boughtItems.Peek().ItemNumberI;
                    _cellsManager.AddBoughtItem(itemNumber);
                    _cellsManager.SetMaxValue(itemNumber);
                    _boughtItems.Dequeue();
                }
            }
        }
    }
}
