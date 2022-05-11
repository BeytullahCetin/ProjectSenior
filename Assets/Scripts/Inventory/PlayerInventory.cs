using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Transform itemInstantiatePoint;
    [SerializeField] InventoryItem[] items;
    InventoryItem selectedItem;

    void Start()
    {
        if (items.Length > 0)
            selectedItem = items[0];
    }


    public void UseItem()
    {
        Throwable t = (Throwable)selectedItem;
        t.Throw(itemInstantiatePoint, GetComponent<PlayerController>().ThrowForce);
        Debug.Log("Instantiate Selected Inventory Item");
    }

}
