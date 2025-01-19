using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemInventari : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    private delegate void OnEnd(ItemObject itemObject);
    private event OnEnd? onEnd;
    public GameObject startCell { get; set; }
    public GameObject endCell { get; set; }
    [SerializeField]
    public ItemObject itemObject;
    [SerializeField]
    public ManagerItem managerItem;
    private Image image;

    private void Start()
    {
        this.image = this.GetComponent<Image>();
        SetStretchStretch(this.GetComponent<RectTransform>());
        onEnd += EndCell;
    }
    private void SetStretchStretch(RectTransform rectTransform)
    {
        rectTransform.anchorMin = new Vector2(0, 0); 
        rectTransform.anchorMax = new Vector2(1, 1); 

        rectTransform.offsetMin = Vector2.zero; 
        rectTransform.offsetMax = Vector2.zero; 

        rectTransform.pivot = new Vector2(0.5f, 0.5f); 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (managerItem.bufItemSettingPanel != null)
            Destroy(managerItem.bufItemSettingPanel);       
        image.raycastTarget = false;
        managerItem.TakeItem = this;
        this.transform.SetParent(managerItem.canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onEnd?.Invoke(itemObject);
    }

    public void EndCell(ItemObject itemObject)
    {
        managerItem.TakeItem = null;
        image.raycastTarget = true;
        if (endCell == null)
        {
            this.transform.SetParent(startCell.transform);
            this.transform.localPosition = Vector3.zero;
            return;
        }
        if (endCell.transform.childCount == 1) 
        {
            this.transform.SetParent(startCell.transform);
            this.transform.localPosition = Vector3.zero;
            return;
        }
        this.transform.SetParent(endCell.transform);
        this.transform.localPosition = Vector3.zero;
        startCell = endCell;
        endCell = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button.ToString() == "Right")
            managerItem.CreateItemSettingPanel(this.gameObject);
    }
}
