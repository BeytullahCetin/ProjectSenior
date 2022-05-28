using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyHand : InventoryItem
{
    Animator handAnim;
    float animationTimeout = 5f;
    float adfads = 0;

    private void Start()
    {
        handAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (adfads < animationTimeout)
            adfads += Time.deltaTime;
    }

    public override void UseInventoryItem()
    {
        Debug.Log("Empty Hand");
        if (adfads >= animationTimeout)
        {
            handAnim.SetTrigger("Action");
            adfads = 0;
        }
    }
}
