using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : InteractableController
{
    public override void Interaction()
    {
        if (canInteractable)
        {
            if (!PlayerInventory.IsObjectiveTaken)
            {
                PlayerInventory.TakeObjective();
                Debug.Log("Objective Status " + PlayerInventory.IsObjectiveTaken);
            }
        }
    }
}
