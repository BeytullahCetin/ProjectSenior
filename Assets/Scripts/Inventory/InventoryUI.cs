using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemAmmo;

    private void OnEnable()
    {
        playerInventory.uptadeUIOnInventoryItemChange += UpdateInventory;
    }

    private void OnDisable()
    {
        playerInventory.uptadeUIOnInventoryItemChange += UpdateInventory;
    }

    private void UpdateInventory(string arg1, string arg2)
    {
        // UI will updated if any event happens.
        itemName.SetText(arg1);
        itemAmmo.SetText(arg2);
    }
}
