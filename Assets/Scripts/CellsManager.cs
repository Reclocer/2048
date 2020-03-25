using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace G2048
{
    public class CellsManager : MonoBehaviour
    {
        [SerializeField] private GameObject _item;
        [SerializeField] private List<Transform> _emptyCells;
        private int _halfEmptyCells;
        [SerializeField] private float _timeDelay = 10;
        private int _maxValueInItems = 1;

        private void Start()
        {
            Initialization();
            InvokeRepeating("CreateItem", 1, _timeDelay);
        }

        private void Initialization()
        {
            _halfEmptyCells = _emptyCells.Count / 2;
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
        #endregion

        private void CreateItem()
        {            
            if (_emptyCells.Count > _halfEmptyCells)
            {
                InstantiateNewItem();
            }
            // else if the list cells is half full
            else if (_emptyCells.Count > 0)
            {                
                int randomValue = Random.Range(1, _maxValueInItems);
                Item item = InstantiateNewItem();
                item.SetIntItemValue(randomValue);                
            }
        }

        private Item InstantiateNewItem()
        {
            Transform randomParentTransform = _emptyCells[Random.Range(0, _emptyCells.Count)];
            _emptyCells.Remove(randomParentTransform);
            Item item = Instantiate(_item, randomParentTransform.position, Quaternion.identity, randomParentTransform).GetComponent<Item>();
            return item;
        }
    }
}
