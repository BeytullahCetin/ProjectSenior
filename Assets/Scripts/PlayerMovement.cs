using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static event Action<Vector2> OnMovement = delegate {};

    Vector2 movementInput;
    Vector3 movement;
    bool isRunning = false;

    [Range(1,10)]
    [SerializeField] float movementSpeed = 3f;
    [Range(1.5f, 5f)]
    [SerializeField]float runSpeedMultiplier = 2f;


    void Update()
    {
        transform.Translate(movement * Time.deltaTime * (isRunning && movement.z > 0 ? runSpeedMultiplier : 1));
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>() * movementSpeed;
        Debug.Log("OnMoveInput: " + context.phase + ": " + movementInput);
        movement.x = movementInput.x;
        movement.z = movementInput.y;

        OnMovement(movementInput);
    }

    public void OnRunInput(InputAction.CallbackContext context)
    {   
        if(context.performed){
            isRunning = !isRunning;
        }
    }
}
