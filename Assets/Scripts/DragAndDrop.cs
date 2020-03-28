using UnityEngine;
using UnityEngine.EventSystems;

namespace G2048
{
    [RequireComponent(typeof(CanvasGroup))]
    public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Item _item;

        private Transform _newParent;
        private Transform _lastParent;
        private CellsManager _cellsManager;
        private CanvasGroup _canvasGroup;

        private void Start()
        {
            Initialization();
        }

        private void Initialization()
        {
            _cellsManager = GameObject.FindGameObjectWithTag("CellsSpace").GetComponent<CellsManager>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        /// <summary>
        /// Event when this gameObject is OnBeginDrag
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            _lastParent = transform.parent;
            _canvasGroup.blocksRaycasts = false;
        }

        /// <summary>
        /// Event when this gameObject is OnDrag
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = new Vector2(Input.mousePosition.x,
                                             Input.mousePosition.y);
        }

        /// <summary>
        /// Event when this gameObject is OnEndDrag
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            Transform pointEnterTransform = eventData.pointerEnter.transform;

            if (pointEnterTransform.tag == "Cell" || 
                pointEnterTransform.tag == "Item" ||
                pointEnterTransform.tag == "Trash")
            {
                // if cell empty
                if (pointEnterTransform.childCount == 0)
                {
                    _newParent = pointEnterTransform;
                    transform.SetParent(_newParent);
                    _cellsManager.AddEmptyCell(_lastParent);
                    _cellsManager.RemoveEmptyCell(_newParent);
                }
                //else if cell not empty and if ItemValue in cell == dragged(this) ItemValue
                else if (pointEnterTransform.tag == "Item" && pointEnterTransform.GetComponent<Item>().ItemValue == _item.ItemValue)
                { 
                    _item.IncrementItemValue();

                    _newParent = pointEnterTransform.parent;
                    transform.SetParent(_newParent);
                    _cellsManager.AddEmptyCell(_lastParent);

                    Destroy(pointEnterTransform.gameObject);
                }
                else if (pointEnterTransform.tag == "Trash")
                {
                    _cellsManager.AddEmptyCell(_lastParent);
                    Destroy(gameObject);                    
                }
                else
                {
                    transform.position = _lastParent.position;
                }
            }
            else
            {
                transform.position = _lastParent.position;
            }

            _canvasGroup.blocksRaycasts = true;
        }       
    }
}
