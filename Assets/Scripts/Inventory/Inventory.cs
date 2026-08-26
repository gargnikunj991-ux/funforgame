using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> items = new Dictionary<string, int>();

    public void AddItem(string itemName, int amount)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName] += amount;
        }
        else
        {
            items.Add(itemName, amount);
        }

        Debug.Log(itemName + " x" + amount + " added.");
    }

    public int GetItemAmount(string itemName)
    {
        if (items.ContainsKey(itemName))
        {
            return items[itemName];
        }

        return 0;
    }
}