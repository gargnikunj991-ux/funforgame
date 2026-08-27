using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<ItemData, int> items =
        new Dictionary<ItemData, int>();

    public void AddItem(ItemData item, int amount)
    {
        if (item == null)
            return;

        if (items.ContainsKey(item))
        {
            items[item] += amount;
        }
        else
        {
            items.Add(item, amount);
        }

        Debug.Log(
            item.itemName + " x" + amount + " added."
        );

        PrintInventory();
    }

    public int GetItemAmount(ItemData item)
    {
        if (item == null)
            return 0;

        if (items.ContainsKey(item))
        {
            return items[item];
        }

        return 0;
    }

    public Dictionary<ItemData, int> GetAllItems()
    {
        return items;
    }

    private void PrintInventory()
    {
        Debug.Log("===== INVENTORY =====");

        foreach (KeyValuePair<ItemData, int> item in items)
        {
            Debug.Log(
                item.Key.itemName + " x" + item.Value
            );
        }

        Debug.Log("=====================");
    }
}