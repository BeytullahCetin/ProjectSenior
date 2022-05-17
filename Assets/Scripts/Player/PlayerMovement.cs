using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static event Action<Vector2> OnMovement = delegate { };
    public static event Action<bool> OnCrouch = delegate { };

    [Range(1, 10)]
    [SerializeField] float movementSpeed = 3f;
    [Range(1.5f, 5f)]
    [SerializeField] float runSpeedMultiplier = 2f;

    Vector2 movementInput;
    Vector3 movement;

    [Header("States")]
    bool isRunning = false;
    bool isCrouching = false;



    void Update()
    {
        transform.Translate(movement * Time.deltaTime * (isRunning && movement.z > 0 ? runSpeedMultiplier : 1));
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

        movement.x = movementInput.x;
        movement.z = movementInput.y;
        movement *= movementSpeed;

        OnMovement(movementInput);
    }

    public void OnRunInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (isRunning)
            {
                case true:
                    isRunning = false;
                    break;

                case false:
                    if(!isCrouching)
                        isRunning = true;
                    break;
            }
        }
    }

    public void OnCrouchInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (isCrouching)
            {
                case true:
                    isCrouching = false;
                    break;
                
                case false:
                    //Slide mechanic can be handled here.
                    isRunning = false;
                    isCrouching = true;
                    break;
            }
            
            OnCrouch(isCrouching);
        }
    }
}
