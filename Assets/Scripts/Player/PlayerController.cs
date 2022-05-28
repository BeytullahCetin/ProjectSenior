using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float throwForce = 1f;

    [SerializeField] float rayDistance  = 1f;
    InteractableController current;
    public float ThrowForce { get { return throwForce; } }

    private void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RaycastHit hit;
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * rayDistance, Color.red, 1f);
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayDistance))
            {
                current = hit.collider.gameObject.GetComponent<InteractableController>();
                if (current != null)
                {
                    current.Interaction();
                }

                current = hit.collider.gameObject.GetComponentInParent<InteractableController>();
                if (current != null)
                {
                    current.Interaction();
                }
            }

        }
    }
}
