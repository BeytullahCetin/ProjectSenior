using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ThrowableType { Default, Light, Sound };

public class Throwable : InventoryItem
{
    Collider[] hitColliders;
    [SerializeField] float radius = 10f;
    bool activated = false;
    List<Enemy> enemiesInRadius = new List<Enemy>();
    [SerializeField] ThrowableType throwableType;
    public ThrowableType GetThrowableType { get { return throwableType; } }

    private void OnCollisionEnter(Collision other)
    {
        if (activated)
            return;

        if (other.gameObject.CompareTag("Ground"))
        {
            ActivateFeature();
            activated = true;
        }
    }

    void ActivateFeature()
    {
        GetEnemiesInRadius();

        foreach (Enemy e in enemiesInRadius)
        {
            e.GoToPosition(transform.position);
            Debug.Log(e.name + ": Activate Feature");
            break;
        }

        enemiesInRadius.Clear();
    }

    void GetEnemiesInRadius()
    {
        hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {

            Enemy e = throwableType == ThrowableType.Light ? hitCollider.GetComponent<Watcher>() : hitCollider.GetComponent<Listener>();
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
