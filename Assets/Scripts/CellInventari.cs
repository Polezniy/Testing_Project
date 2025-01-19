using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellInventari : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public ManagerItem managerItem;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (managerItem.TakeItem == null)
            return;
        managerItem.TakeItem.endCell = this.gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (managerItem.TakeItem == null)
            return;
        managerItem.TakeItem.endCell = null;
    }
}
