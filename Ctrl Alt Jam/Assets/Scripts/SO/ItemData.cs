using UnityEngine;

[CreateAssetMenu(menuName = "Data/Items")]
public class ItemData : ScriptableObject
{
    public int id;
    public string itemName;

    public Sprite ItemIcon;
    public Sprite itemSprite;

    [TextArea(5,5)]
    public string itemDescription;
}
