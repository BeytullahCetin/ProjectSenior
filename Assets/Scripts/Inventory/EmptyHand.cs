using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyHand : InventoryItem
{
    Animator handAnim;
    [SerializeField] float animationTimeout = 2.5f;
    float requiredTime;

    private void Start()
    {
        handAnim = GetComponent<Animator>();
        requiredTime = animationTimeout;
    }

    private void Update()
    {
        if (requiredTime < animationTimeout)
            requiredTime += Time.deltaTime;
    }

    public override void UseInventoryItem()
    {
        Debug.Log("Empty Hand");
        if (requiredTime >= animationTimeout)
        {
            handAnim.SetTrigger("Action");
            requiredTime = 0;
        }
    }
}
