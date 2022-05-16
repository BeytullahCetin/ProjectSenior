using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Throwable;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Transform itemInstantiatePoint;
    [SerializeField] InventoryItem[] items;
    [SerializeField] Dictionary<InventoryItem, float> itemsAmmos;
    InventoryItem selectedItem;
    int selectedItemIndex = 0;

    void Start()
    {
        itemsAmmos = new Dictionary<InventoryItem, float>();

        for (int i = 0; i < items.Length; i++)
        {
            InventoryItem item = items[i];
            itemsAmmos.Add(item, 0);
        }

        if (items.Length > 0)
            selectedItem = items[selectedItemIndex];
    }

    public void UseItem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            switch (selectedItem.GetType().ToString())
            {
                case "Throwable":
                    if (itemsAmmos[selectedItem] > 0)
                    {
                        selectedItem.UseInventoryItem(itemInstantiatePoint, GetComponent<PlayerController>().ThrowForce);
                        itemsAmmos[selectedItem]--;
                        Debug.Log(itemsAmmos[selectedItem]);
                    }
                    break;

                case "EmptyHand":
                    selectedItem.UseInventoryItem();
                    break;
            }
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
        }
    }

    public void AddAmmo(string type)
    {
        foreach (InventoryItem i in items)
        {
            Throwable throwable = i.GetComponent<Throwable>();
            if (throwable.GetThrowableType.ToString() == type)
            {
                itemsAmmos[throwable]++;
                Debug.Log(itemsAmmos[throwable]);
                break;
            }
        }
    }
}
