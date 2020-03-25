using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace G2048
{
    public class Item : MonoBehaviour
    {
        private CellsManager _cellsManager;
        private ScoreManager _scoreManager;
    
        [SerializeField] private Text _amountTextComponent;
        private int _itemValue = 1;
        public int ItemValue => _itemValue;

        private void Start()
        {
            _cellsManager = GameObject.FindGameObjectWithTag("CellsSpace").GetComponent<CellsManager>();
            _scoreManager = GameObject.FindGameObjectWithTag("Score")     .GetComponent<ScoreManager>();
        }

        /// <summary>
        /// Set value (type of int) 
        /// </summary>
        /// <param name="value"></param>
        public void SetIntItemValue(int value)
        {
            _itemValue = value;
            _amountTextComponent.text = _itemValue.ToString();
        }

        /// <summary>
        /// Increment item value
        /// </summary>
        public void IncrementItemValue()
        {
            _itemValue++;
            _amountTextComponent.text = _itemValue.ToString();

            _cellsManager.SetMaxValue(_itemValue);
            _scoreManager.IncrementScore(_itemValue);
        }
    }
}