using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Throwable;

public class PlayerInventory : MonoBehaviour
{
    public event Action<string, string> uptadeUIOnInventoryItemChange = delegate { };

    [SerializeField] Transform itemInstantiatePoint;
    [SerializeField] InventoryItem[] items;
    [SerializeField] Dictionary<InventoryItem, float> itemsAmmos;
    [SerializeField] Transform inventoryItemContainer;
    InventoryItem selectedItem;
    int selectedItemIndex = 0;

    void Start()
    {
        // itemAmmos declared
        itemsAmmos = new Dictionary<InventoryItem, float>();

        // itemAmmos filled with items and 0's
        //It will hold information for which item has how many ammos
        for (int i = 0; i < items.Length; i++)
        {
            InventoryItem item = items[i];
            itemsAmmos.Add(item, 0);
        }

        // selectedItem is assigned to first element of items
        if (items.Length > 0)
            selectedItem = items[selectedItemIndex];

        CreateSelectedItem();
    }

    public void UseItem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
            switch (selectedItem.GetType().ToString())
            {
                // Selected item's UseInventoryItem function will called.
                case "Throwable":
                    // If inventory item is a throwable ammo check is required
                    if (itemsAmmos[items[selectedItemIndex]] > 0)
                    {
                        // If there are eneough ammo UseInevtoryItem function called and 1 ammo decreased
                        selectedItem.UseInventoryItem(itemInstantiatePoint, GetComponent<PlayerController>().ThrowForce);
                        itemsAmmos[items[selectedItemIndex]]--;
                    }
                    break;

                case "EmptyHand":
                    selectedItem.UseInventoryItem();
                    break;
            }
            // After item used UI should be updated for any ammo change event
            UpdateInventoryUI();
        }
    }

    public void ChangeSelectedItem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 value = context.ReadValue<Vector2>();

            if (value.y < 0)
            {
                //Select next inventory item
                selectedItemIndex = selectedItemIndex < items.Length - 1 ? selectedItemIndex + 1 : 0;
            }
            else if (value.y > 0)
            {
                //Select previous inventory item
                selectedItemIndex = selectedItemIndex > 0 ? selectedItemIndex - 1 : items.Length - 1;
            }
            selectedItem = items[selectedItemIndex];

            // After item changed UI should be updated for item name and ammo change
            UpdateInventoryUI();

            CreateSelectedItem();
        }
    }

    void UpdateInventoryUI()
    {
        // An event that InventyUI listening trigerred for selected item
        if (selectedItem.GetType().ToString() == "EmptyHand")
            uptadeUIOnInventoryItemChange("Hands", "-");
        else
            uptadeUIOnInventoryItemChange(selectedItem.GetComponent<Throwable>().GetThrowableType.ToString(), itemsAmmos[items[selectedItemIndex]].ToString());

    }

    public void AddAmmo(string type)
    {
        // For any given item type add 1 ammo
        foreach (InventoryItem i in items)
        {
            Throwable throwable = i.GetComponent<Throwable>();
            if (throwable != null)
            {
                if (throwable.GetThrowableType.ToString() == type)
                {
                    itemsAmmos[throwable]++;
                    break;
                }
            }
        }
        // After ammo changes, inventory must updated
        UpdateInventoryUI();
    }

    void CreateSelectedItem()
    {
        // After selected item changed
        // selected item must created on the screen

        if (inventoryItemContainer.transform.childCount > 0)
        {
            // First any other objects must destroyed for any conflicts can happen
            foreach (Transform child in inventoryItemContainer.transform)
            {
                Destroy(child.gameObject);
            }
        }

        // Then instantiated, assigned to parent, repositioned and rotated
        selectedItem = Instantiate(selectedItem);
        selectedItem.transform.parent = inventoryItemContainer;
        selectedItem.transform.localPosition = Vector3.zero;
        selectedItem.transform.localRotation = Quaternion.identity;
    }
}
