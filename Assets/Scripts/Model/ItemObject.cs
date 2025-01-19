using UnityEngine;

[CreateAssetMenu(menuName = "Item_Object")]
public class ItemObject : ScriptableObject
{
    [SerializeField]
    public string Name;

    [SerializeField]
    public Sprite Sprite;
}
