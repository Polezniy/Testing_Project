using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSettingInventari : MonoBehaviour
{
    public Button buttonDelete;

    public void CreateAction(GameObject itemInventari)
    {
        Button.ButtonClickedEvent e = new Button.ButtonClickedEvent();
        e.AddListener(() => DeleteItem(itemInventari));
        buttonDelete.onClick = e;
    }

    private void DeleteItem(GameObject itemInventari)
    {
        Destroy(itemInventari);
        Destroy(this.gameObject);
    }
}
