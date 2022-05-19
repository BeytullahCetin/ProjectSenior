using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : InteractableController
{
    public event Action OnObjectiveTaken = delegate { };

    public override void Interaction()
    {
        if (canInteractable)
        {
            OnObjectiveTaken();
            Debug.Log("Objective Interaction");
        }
    }
}
