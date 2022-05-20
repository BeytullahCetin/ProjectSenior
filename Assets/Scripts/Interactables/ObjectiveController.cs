using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : LureController
{
    public event Action OnObjectiveTaken = delegate { };

    public override void Interaction()
    {
        if (canInteractable)
        {
            ActivateLure();
            OnObjectiveTaken();
            Debug.Log("Objective Interaction");
        }
    }
}
