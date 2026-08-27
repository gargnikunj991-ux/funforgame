using UnityEngine;

public enum ItemType
{
    Resource,
    Food,
    Tool,
    Weapon,
    Material,
    Quest
}

[CreateAssetMenu(
    fileName = "NewItem",
    menuName = "Survival Game/Item Data"
)]
public class ItemData : ScriptableObject
{
    [Header("Basic Information")]
    public string itemName;
    public ItemType itemType;

    [TextArea(2, 5)]
    public string description;

    [Header("Inventory")]
    public int maxStackSize = 99;

    [Header("Visual")]
    public Sprite icon;
}