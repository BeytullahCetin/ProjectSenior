using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Transform itemInstantiatePoint;
    [SerializeField] InventoryItem[] items;
    InventoryItem selectedItem;
    int selectedItemIndex = 0;

    void Start()
    {
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
                    selectedItem.UseInventoryItem(itemInstantiatePoint, GetComponent<PlayerController>().ThrowForce);
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
            Debug.Log(selectedItemIndex);
            selectedItem = items[selectedItemIndex];
        }
    }
}
