using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float throwForce = 1f;
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

            Debug.Log("Raycast");

            RaycastHit hit;
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * 10, Color.red, 1f);
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 10))
            {
                current = hit.collider.gameObject.GetComponentInParent<ObjectiveController>();
                if (current != null)
                {
                    current.Interaction();
                }
            }

        }
    }
}
