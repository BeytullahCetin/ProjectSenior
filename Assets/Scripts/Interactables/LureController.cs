using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureController : InteractableController
{
    [SerializeField] Enemy[] EnemiesToLure;

    public void ActivateLure()
    {
        // If a lure activeted all enemies
        //inside EnemiesToLure will be alerted.
        foreach (Enemy enemy in EnemiesToLure)
        {
            enemy.GoToPosition(transform.position);
        }
    }
}
