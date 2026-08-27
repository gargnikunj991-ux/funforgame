using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text quantityText;

    public void SetItem(ItemData item, int amount)
    {
        gameObject.SetActive(true);

        quantityText.text = amount.ToString();

        if (item.icon != null)
        {
            itemIcon.sprite = item.icon;
            itemIcon.color = Color.white;
        }
        else
        {
            // Temporary visual until we add real icons.
            if (item.itemName == "Wood")
            {
                itemIcon.color = new Color(
                    0.55f,
                    0.27f,
                    0.08f
                );
            }
            else if (item.itemName == "Stone")
            {
                itemIcon.color = Color.gray;
            }
        }
    }

    public void ClearSlot()
    {
        quantityText.text = "";
        itemIcon.sprite = null;
        itemIcon.color = Color.clear;
    }
}