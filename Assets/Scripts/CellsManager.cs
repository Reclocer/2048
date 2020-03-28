using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace G2048
{
    public class CellsManager : MonoBehaviour
    {
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private float _timeDelay = 10;
        private float _time = 0; 
        private int _maxValueInItems = 1;
        private Queue<int> _boughtItems;

        [SerializeField] private List<Transform> _emptyCells;
        private int _halfEmptyCellsI;
        private bool _halfEmptyCellsB = false;       

        private void Start()
        {
            Initialization();            
        }

        private void Initialization()
        {
            _boughtItems = new Queue<int>();
            _halfEmptyCellsI = _emptyCells.Count / 2;
        }

        private void Update()
        {
            if(_time >= _timeDelay)
            {
                CreateItem();
                _time -= _timeDelay;
            }
            else
            {
                _time += Time.deltaTime;
            }
        }

        #region GetSet   
        /// <summary>
        /// Get list with empty cells 
        /// </summary>
        /// <returns></returns>
        public List<Transform> GetEmptyCells()
        {
            return _emptyCells;
        }

        /// <summary>
        /// Add empty cell in list "_emptyCells"
        /// </summary>
        /// <param name="emptyCell"></param>
        public void AddEmptyCell(Transform emptyCell)
        {
            _emptyCells.Add(emptyCell);
        }

        /// <summary>
        /// Remove empty cell in list "_emptyCells"
        /// </summary>
        /// <param name="emptyCell"></param>
        public void RemoveEmptyCell(Transform emptyCell)
        {
            _emptyCells.Remove(emptyCell);
        }

        /// <summary>
        /// Set max value if param value > _maxValueInItem
        /// </summary>
        /// <param name="value"></param>
        public void SetMaxValue(int value)
        {
            if(value > _maxValueInItems)
            {
                _maxValueInItems = value;
            }
        }

        /// <summary>
        /// Add bought item value in queue
        /// </summary>
        /// <param name="itemValue"></param>
        public void AddBoughtItem(int itemValue)
        {
            _boughtItems.Enqueue(itemValue);            
        }
        #endregion

        private void CreateItem()
        {
            if (_emptyCells.Count > 0)
            {
                //if there is a bought item
                if (_boughtItems.Count > 0)
                {
                    Item item = InstantiateNewItem();
                    int itemValue = _boughtItems.Peek();
                    _boughtItems.Dequeue();
                    item.SetIntItemValue(itemValue);
                }
                else if (_emptyCells.Count > _halfEmptyCellsI && _halfEmptyCellsB == false)
                {
                    InstantiateNewItem();
                }
                // else if the list cells is half full
                else
                {
                    Item item = InstantiateNewItem();
                    int randomValue = Random.Range(1, _maxValueInItems);
                    item.SetIntItemValue(randomValue);
                    _halfEmptyCellsB = true;
                }
            }
        }

        private Item InstantiateNewItem()
        {
            Transform randomParentTransform = _emptyCells[Random.Range(0, _emptyCells.Count)];
            _emptyCells.Remove(randomParentTransform);
            Item item = Instantiate(_itemPrefab, randomParentTransform.position, Quaternion.identity, randomParentTransform).GetComponent<Item>();
            return item;
        }
    }
}
