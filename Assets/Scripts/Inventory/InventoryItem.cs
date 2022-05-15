using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItem : MonoBehaviour
{   
    public virtual void UseInventoryItem(){Debug.Log("InventoryItem");}
    public virtual void UseInventoryItem(Transform t, float throwForce){}
}
