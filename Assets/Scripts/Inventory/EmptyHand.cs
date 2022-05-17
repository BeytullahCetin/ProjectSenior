using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyHand : InventoryItem
{
    public override void UseInventoryItem()
    {
        Debug.Log("Empty Hand");
    }
}
