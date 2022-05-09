using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Throwable : InventoryItem
{
    [SerializeField] float radius = 5f;
    List<Enemy> enemiesInRadius = new List<Enemy>();

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
           ActivateFeature();
    }

    void GetEnemiesInRadius()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            Enemy e = hitCollider.GetComponent<Enemy>();
            if(e != null){
                enemiesInRadius.Add(e);
                Debug.Log(e.name + ": GetEnemiesInRadius");
            }
                
        }

    }

    void ActivateFeature()
    {
        GetEnemiesInRadius();

        foreach(Enemy e in enemiesInRadius)
        {
            e.GoToPosition(transform.position);
            Debug.Log(e.name + ": Activate Feature");
        }

        enemiesInRadius.Clear();
    }
}
