using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerItem : MonoBehaviour
{
    public ItemInventari? TakeItem { get; set; } = null;
    public GameObject bufItemSettingPanel { get; set; }
    [SerializeField]
    public GameObject cells;
    [SerializeField]
    public List<ItemObject> itemObjects;
    [SerializeField]
    public GameObject canvas;
    [SerializeField]
    public GameObject ptefabItemSettingPanel;
    [SerializeField]
    public Vector3 spawnOffset;
    public void CreateItemObjToInventory(ItemObject itemObject)
    {
        var cell = GetClearCell(cells);
        if (cell == null)
        {
            return;
        }
        var itemGO = new GameObject();
        itemGO.transform.SetParent(cell.transform);
        itemGO.transform.localPosition = Vector3.zero;
        itemGO.transform.localScale = Vector3.one;
        itemGO.AddComponent<Image>().sprite = itemObject.Sprite;
        var item = itemGO.AddComponent<ItemInventari>();
        item.itemObject = itemObject;
        item.startCell = cell;
        item.managerItem = this;
    }

    public void CreateItemObjToInventoryRandom()
    {
        CreateItemObjToInventory(itemObjects[Random.Range(0, itemObjects.Count)]);
    }
    private GameObject GetClearCell(GameObject cells)
    {
        for (int i = 0; i < cells.transform.childCount; i++)
        {
            if (cells.transform.GetChild(i).childCount == 0)
            {
                return cells.transform.GetChild(i).gameObject;
            }
        }
        return null;
    }

    public void CreateItemSettingPanel(GameObject itemInventari)
    {
        if (itemInventari != null)        
            Destroy(bufItemSettingPanel);        
        var panelSettingItem = Instantiate(ptefabItemSettingPanel, canvas.transform);
        panelSettingItem.GetComponent<ItemSettingInventari>().CreateAction(itemInventari);
        panelSettingItem.transform.position = Input.mousePosition;
        panelSettingItem.transform.position += spawnOffset;
        bufItemSettingPanel = panelSettingItem;
    }
}
