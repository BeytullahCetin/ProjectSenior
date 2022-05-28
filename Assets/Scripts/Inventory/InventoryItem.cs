using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItem : MonoBehaviour
{   
    [SerializeField] float selfDestructTime = 15f;

    public virtual void UseInventoryItem(){}
    public virtual void UseInventoryItem(Transform t, float throwForce){}

    IEnumerator Start() {
        yield return new WaitForSeconds(selfDestructTime);
        Destroy(gameObject);
    }
}
