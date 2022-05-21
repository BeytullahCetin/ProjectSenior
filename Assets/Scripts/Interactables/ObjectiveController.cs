using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : LureController
{
    public event Action<ObjectiveController> OnObjectiveTaken = delegate { };

    public override void Interaction()
    {
        if (canInteractable)
        {
            ActivateLure();
            OnObjectiveTaken(this);
            Debug.Log("Objective Interaction");
            Destroy(gameObject);
        }
    }
}
