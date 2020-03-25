using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace G2048
{
    public class ScoreManager : DoSingleton<ScoreManager>
    {
        [SerializeField] private Text _scoreValueT;
        [SerializeField] private int _coefficient = 25;
        private int _scoreValueI = 0;        

        protected override void Awake()
        {
            base.Awake();            
        }

        /// <summary>
        /// Increment score value
        /// </summary>
        /// <param name="value"></param>
        public void IncrementScore(int value)
        {
            if (value >= 0)
            {
                _scoreValueI += value*_coefficient;
                _scoreValueT.text = _scoreValueI.ToString();
            }
            else
            {
                _scoreValueI += Mathf.Abs(value)*_coefficient;
                _scoreValueT.text = _scoreValueI.ToString();
                Debug.Log("Please add value > 0");
            }
        }

        /// <summary>
        /// Decrement score value
        /// </summary>
        /// <param name="value"></param>
        public void DecrementScore(int value)
        {
            if (value >= 0)
            {
                _scoreValueI -= value;
                _scoreValueT.text = _scoreValueI.ToString();
            }
            else
            {
                _scoreValueI -= Mathf.Abs(value);
                _scoreValueT.text = _scoreValueI.ToString();
                Debug.Log("Please add value > 0");
            }
        }

        protected override ScoreManager GetInstance()
        {
            return this;
        }
    }
}
