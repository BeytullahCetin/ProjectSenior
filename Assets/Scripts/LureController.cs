using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureController : CollectibleController
{
    [SerializeField] Enemy[] EnemiesToLure;

    public void ActivateLure()
    {
        foreach (Enemy enemy in EnemiesToLure)
        {
            enemy.GoToPosition(transform.position);
        }
    }
}
