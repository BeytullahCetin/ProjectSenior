using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float throwForce = 1f;
    public float ThrowForce { get { return throwForce; } }

    public void Interact(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            CollectibleController current = hit.collider.gameObject.GetComponent<CollectibleController>();
            if (current != null)
            {
                current.Interaction();
            }
        }
    }
}
