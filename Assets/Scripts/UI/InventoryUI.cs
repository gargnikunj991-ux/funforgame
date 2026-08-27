using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Transform slotsContainer;

    private Inventory inventory;
    private InventorySlot[] slots;

    private void Start()
    {
        inventoryPanel.SetActive(false);

        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            inventory = player.GetComponent<Inventory>();
        }

        slots =
            slotsContainer.GetComponentsInChildren<InventorySlot>(
                true
            );

        ClearAllSlots();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        bool isOpening =
            !inventoryPanel.activeSelf;

        inventoryPanel.SetActive(isOpening);

        if (isOpening)
        {
            UpdateInventoryUI();
        }
    }

    private void UpdateInventoryUI()
    {
        if (inventory == null)
            return;

        ClearAllSlots();

        Dictionary<ItemData, int> items =
            inventory.GetAllItems();

        int slotIndex = 0;

        foreach (KeyValuePair<ItemData, int> item in items)
        {
            if (slotIndex >= slots.Length)
                break;

            slots[slotIndex].SetItem(
                item.Key,
                item.Value
            );

            slotIndex++;
        }
    }

    private void ClearAllSlots()
    {
        if (slots == null)
            return;

        foreach (InventorySlot slot in slots)
        {
            slot.ClearSlot();
        }
    }
}