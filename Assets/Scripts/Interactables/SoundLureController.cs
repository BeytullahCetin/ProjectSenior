using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLureController : LureController
{
    public override void Interaction()
    {
        if (canInteractable && !isUsed)
        {
            Debug.Log("Interaction LureController");
        }
    }

}
