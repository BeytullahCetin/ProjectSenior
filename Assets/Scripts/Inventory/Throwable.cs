using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Throwable : InventoryItem
{
    [SerializeField] float radius = 10f;
    bool activated = false;
    List<Enemy> enemiesInRadius = new List<Enemy>();

    private void OnCollisionEnter(Collision other)
    {
        if (activated)
            return;

        ActivateFeature();
        activated = true;
    }

    void ActivateFeature()
    {
        GetEnemiesInRadius();

        foreach (Enemy e in enemiesInRadius)
        {
            e.GoToPosition(transform.position);
            Debug.Log(e.name + ": Activate Feature");
        }

        enemiesInRadius.Clear();
    }

    void GetEnemiesInRadius()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            Enemy e = hitCollider.GetComponent<Enemy>();
            if (e != null)
            {
                enemiesInRadius.Add(e);
                Debug.Log(e.name + ": GetEnemiesInRadius");
            }

        }
    }

    public override void UseInventoryItem(Transform t, float throwForce)
    {
        Throwable obj = Instantiate(this, t.position, Quaternion.identity);
        Rigidbody objRigidbody = obj.GetComponent<Rigidbody>();
        float randomNumber = Random.Range(0, 1);
        objRigidbody.AddTorque(new Vector3(randomNumber, randomNumber, randomNumber));
        objRigidbody.AddForce(t.forward * throwForce);
    }


}
