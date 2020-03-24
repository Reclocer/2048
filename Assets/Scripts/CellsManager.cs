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
        private int _maxValueInItem = 10;// need max value in items

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
        public List<Transform> GetEmptyCells()
        {
            return _emptyCells;
        }

        public void AddEmptyCell(Transform emptyCell)
        {
            _emptyCells.Add(emptyCell);
        }

        public void RemoveEmptyCell(Transform emptyCell)
        {
            _emptyCells.Remove(emptyCell);
        }
        #endregion

        private void CreateItem()
        {
            if (_emptyCells.Count > _halfEmptyCells)
            {
                Transform randomParentTransform = _emptyCells[Random.Range(0, _emptyCells.Count)];
                _emptyCells.Remove(randomParentTransform);
                GameObject item = Instantiate(_item, randomParentTransform.position, Quaternion.identity, randomParentTransform);
            }
            else if (_emptyCells.Count > 0)
            {
                Transform randomParentTransform = _emptyCells[Random.Range(0, _emptyCells.Count)];
                _emptyCells.Remove(randomParentTransform);
                GameObject item = Instantiate(_item, randomParentTransform.position, Quaternion.identity, randomParentTransform);
                string randomValue = Random.Range(1, _maxValueInItem).ToString();
                item.GetComponentInChildren<Text>().text = randomValue;
            }
        }
    }
}
