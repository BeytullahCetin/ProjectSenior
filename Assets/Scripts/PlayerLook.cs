using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    Vector2 lookInput;
    float lookX;
    float lookY;


    [SerializeField] Transform camTransform;
    [Range(1, 10)]
    [SerializeField] float lookSpeed = 1f;


    void Update()
    {
        transform.Rotate(Vector3.up, lookX);
        camTransform.Rotate(Vector3.right, lookY);
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>() * lookSpeed;
        lookX = lookInput.x;
        lookY = -lookInput.y;
    }
}
