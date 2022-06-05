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
        // requiredTime will increase every frame until
        //it equals to timeout number.
        if (requiredTime < animationTimeout)
            requiredTime += Time.deltaTime;
    }

    public override void UseInventoryItem()
    {
        // Hand animation will play if required time is greater or equal to animation timeout
        if (requiredTime >= animationTimeout)
        {
            handAnim.SetTrigger("Action");
            requiredTime = 0;
        }
    }
}
