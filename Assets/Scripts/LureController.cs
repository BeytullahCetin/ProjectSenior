using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureController : InteractableController
{
    [SerializeField] Enemy[] EnemiesToLure;

    public void ActivateLure()
    {
        foreach (Enemy enemy in EnemiesToLure)
        {
            enemy.GoToPosition(transform.position);
        }
    }

    public override void Interaction()
    {
        if (canInteractable)
            Debug.Log("Interaction LureController");
    }
}
